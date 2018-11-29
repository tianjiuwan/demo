using UnityEngine;
using System.Collections;
using LuaInterface;
using System;
using System.IO;


public class AppMain : MonoBehaviour
{
    LuaState lua = null;
    private string strLog = "";


    void Start()
    {
        InputMgr.Instance.initialize();
        ManifestMgr.Init();
        AtlasMgr.Instance.Init();
#if UNITY_5 || UNITY_2017 || UNITY_2018
        Application.logMessageReceived += Log;
#else
        Application.RegisterLogCallback(Log);
#endif         
        lua = new LuaState();
        lua.Start();
        LuaBinder.Bind(lua);
        DelegateFactory.Register();
        string fullPath = Path.Combine(Application.dataPath, "LuaScripts/Scripts");
        lua.AddSearchPath(fullPath);
        lua.DoFile("__init.lua");
        LogicFrame.Instance.initialize(lua);
        GameSocket.Instance.run("192.168.1.108", "8007");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) {
            int HEAD_LEN = 18;//包头长度
            short HEAD_FIX = 0x71ab;

            pb.PlayerSnapShootMsg msg = new pb.PlayerSnapShootMsg();
            msg.playerId = 80000060;
            msg.username = "cocotang";
            byte[] data = ProtobufSerializer.Serialize<pb.PlayerSnapShootMsg>(msg);
            int len = data.Length;
            ByteBuffer buffer = ByteBuffer.Allocate(len + HEAD_LEN);
            buffer.WriteShort(HEAD_FIX);
            buffer.WriteShort((short)(HEAD_LEN + len));
            buffer.WriteShort(12001);
            buffer.WriteLong(90000001001);
            buffer.WriteInt(0);
            buffer.WriteBytes(data);
            GameSocket.Instance.Send(buffer);
            Debug.LogError("发送一条消息给服务器");
        }
    }

    void Log(string msg, string stackTrace, LogType type)
    {
        strLog += msg;
        strLog += "\r\n";
    }


    void OnApplicationQuit()
    {
        lua.Dispose();
        lua = null;
#if UNITY_5 || UNITY_2017 || UNITY_2018	
        Application.logMessageReceived -= Log;
#else
        Application.RegisterLogCallback(null);
#endif 
    }

}
