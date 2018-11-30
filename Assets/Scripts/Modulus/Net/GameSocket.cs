using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;

public class GameSocket : Singleton<GameSocket>
{
    public const int MAX_BUFFER_SIZE = 65535;//缓冲大小
    public const int HEAD_LEN = 18;//包头长度
    private Int32 now = 0;//写入起点
    private Int32 bytesRead = 0;//写入的字节数

    private Socket _socket;
    private Thread _receiveThread;
    private Queue<byte[]> _recQueue = new Queue<byte[]>();
    private byte[] _recvBuffer = new byte[MAX_BUFFER_SIZE];

    public void run(string ipAdd, string port)
    {
        IPAddress ip = IPAddress.Parse(ipAdd);
        IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //_socket.Connect(point);
        _socket.ReceiveBufferSize = MAX_BUFFER_SIZE;
        _socket.NoDelay = true;
        IAsyncResult connResult = _socket.BeginConnect(ip, int.Parse(port), null, null);
        connResult.AsyncWaitHandle.WaitOne(2000, true);  //等待2秒

        if (connResult.IsCompleted)
        {
            _receiveThread = new Thread(new ThreadStart(onReceive));
            _receiveThread.IsBackground = true;
            if (!_receiveThread.IsAlive)
                _receiveThread.Start();
        }
    }


    public void onReceive()
    {
        do
        {
            //缓冲剩余的大小
            int size = MAX_BUFFER_SIZE - now;
            if (size > 0)
            {
                //接受 now起点 size大小 bytesRead接受的字节大小
                bytesRead = _socket.Receive(_recvBuffer, now, size, SocketFlags.None);
                now += bytesRead;
                splitPacket();                
            }
        } while (true);
    }

    //拆包
    private void splitPacket()
    {
        if (now >= HEAD_LEN)
        {
            //包头信息有了 解出包长
            int len = getPacketLen();
            //如果有整包的长度            
            if (now >= len)
            {
                byte[] packet = new byte[len];
                Buffer.BlockCopy(_recvBuffer, 0, packet, 0, len);
                //前移buffer
                Buffer.BlockCopy(_recvBuffer, len, _recvBuffer, 0, now - len);
                now -= len;                
                decoderPacket(packet);
                splitPacket();
            }
        }
    }

    /// <summary>
    /// 完整的包
    /// </summary>
    /// <param name="packet"></param>
    private void decoderPacket(byte[] packet)
    {
        ByteBuffer byteBuffer = ByteBuffer.Allocate(packet);
        short headFlag = byteBuffer.ReadShort();
        short len = byteBuffer.ReadShort();
        short code = byteBuffer.ReadShort();
        long playerId = byteBuffer.ReadLong();
        int encryId = byteBuffer.ReadInt();
        len -= HEAD_LEN;
        byte[] data = new byte[len];
        byteBuffer.ReadBytes(data, 0, len);
        pb.PlayerSnapShootMsg msg = ProtobufSerializer.DeSerialize<pb.PlayerSnapShootMsg>(data);
        UnityEngine.Debug.LogError("msg user name " + msg.username);
    }

    /// <summary>
    /// 获取包长
    ///  flag short
    ///  len short
    ///  cmd short 
    ///  long playerid
    ///  encryid int 
    /// </summary>
    /// <returns></returns>
    private int getPacketLen()
    {
        byte[] head = new byte[HEAD_LEN];
        Buffer.BlockCopy(_recvBuffer, 0, head, 0, HEAD_LEN);
        ByteBuffer byteBuffer = ByteBuffer.Allocate(head);
        short headFlag = byteBuffer.ReadShort();
        short len = byteBuffer.ReadShort();
        short code = byteBuffer.ReadShort();
        return len;
    }

    public void Send(ByteBuffer byteBuffer)
    {
        byte[] buffer = new byte[byteBuffer.ReadableBytes()];
        byteBuffer.ReadBytes(buffer, 0, byteBuffer.ReadableBytes());
        onSend(buffer);
    }

    private void onSend(byte[] buffer)
    {
        if (_socket != null && _socket.Connected)
        {
            _socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
    }

    public void onDispose()
    {
        if (_receiveThread != null && _receiveThread.IsAlive)
        {
            _receiveThread.Abort();
        }
        _receiveThread = null;
        if (_socket != null)
            _socket.Close();
        _socket = null;
    }

}

