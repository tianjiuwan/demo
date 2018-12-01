using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using LuaInterface;

public class LogicFrame:Singleton<LogicFrame>
{
    private int frameIndex = 0;
    public int FrameIndex {
        get {
            return frameIndex;
        }
    }
    private LuaState luaState = null;
    LuaFunction luaFunc = null;
    LuaFunction netFun = null;

    public void initialize(LuaState state)
    {
        //if (frameTick != null) return;
        //frameTick = new Thread(startThread);
        luaState = state;
        luaFunc = luaState.GetFunction("TimeMgr.tick");
        netFun = luaState.GetFunction("TimeMgr.onNetMsg");
        LoadThread.Instance.StartCoroutine(tick());
    }

    /// <summary>
    /// call lua net fun
    /// </summary>
    /// <param name="pbs"></param>
    private void callLuaNetFun(PBMessage pbs) {
        netFun.Call(pbs);
    }

    IEnumerator tick() {
        while (true) {
            PBMessage pbs = GameSocket.Instance.getMsg();
            if (pbs != null) {
                callLuaNetFun(pbs);
            }
            yield return new WaitForEndOfFrame();
            frameIndex++;
            //SkillMgr.Instance.tick(frameIndex);
            if (luaFunc != null) {
                luaFunc.Call(frameIndex);
            }
        }
    }
}

