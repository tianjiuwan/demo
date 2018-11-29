using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMainTest : MonoBehaviour
{

    private void Start()
    {
        pb.PlayerSnapShootMsg msg = new pb.PlayerSnapShootMsg();
        msg.username = "cocotang";
        msg.playerId = 9000001;
        byte[] data = ProtobufSerializer.Serialize(msg);
        Debug.LogError("data len " + data.Length);
        ByteBuffer buffer = ByteBuffer.Allocate(1024);
        buffer.WriteShort(1001);
        buffer.WriteShort(1002);
        buffer.WriteShort(1003);
        buffer.WriteLong(10055555);
        buffer.WriteBytes(data);

        short s1 = buffer.ReadShort();
        short s2 = buffer.ReadShort();
        short s3 = buffer.ReadShort();
        long l1 = buffer.ReadLong();
        byte[] readData = new byte[buffer.ReadableBytes()];
        buffer.ReadBytes(readData, 0, buffer.ReadableBytes());
        Debug.LogError("readData len " + readData.Length);
        pb.PlayerSnapShootMsg dmsg = ProtobufSerializer.DeSerialize<pb.PlayerSnapShootMsg>(readData);
        Debug.LogError("user name " + dmsg.username);

        //socket receive bytes
        //

    }

}
