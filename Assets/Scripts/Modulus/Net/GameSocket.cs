using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;

public class GameSocket:Singleton<GameSocket>
{
    private Socket _socket;
    private Thread _receiveThread;    

    public void run(string ipAdd,string port) {
        IPAddress ip = IPAddress.Parse(ipAdd);
        IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _socket.Connect(point);
        _receiveThread = new Thread(onReceive);
        _receiveThread.IsBackground = true;
        _receiveThread.Start();
    }


    private void onReceive() {
        while (true) {
            byte[] buffer = new byte[1024 * 1024];
            int n = _socket.Receive(buffer);
            if (n > 0)
            {

            }
            else {

            }
        }
    }
    private void onSend(byte[] buffer) {
        if (_socket != null) {
            _socket.Send(buffer);
        }
    }

}

