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
