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
        LogicFrame.Instance.initialize();
        LoaderMgr.Instance.initialize();
        ManifsetMgr.Instance.initislize();
        AtlasMgr.Instance.initialize();
#if UNITY_5 || UNITY_2017 || UNITY_2018
        Application.logMessageReceived += Log;
#else
        Application.RegisterLogCallback(Log);
#endif         
        lua = new LuaState();
        lua.Start();
        //如果移动了ToLua目录，自己手动修复吧，只是例子就不做配置了
        string fullPath = Path.Combine(Application.dataPath, "LuaScripts/Scripts");
        lua.AddSearchPath(fullPath);
        lua.DoFile("__init.lua");
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
