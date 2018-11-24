using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using LuaInterface;

public class LogicFrame
{
    private static LogicFrame instance;
    public static LogicFrame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LogicFrame();
            }
            return instance;
        }
    }

    private int frameIndex = 0;
    public int FrameIndex {
        get {
            return frameIndex;
        }
    }
    private LuaState luaState = null;
    LuaFunction luaFunc = null;
    public void initialize(LuaState state)
    {
        //if (frameTick != null) return;
        //frameTick = new Thread(startThread);
        luaState = state;
        luaFunc = luaState.GetFunction("TimeMgr.tick");
        LoadThread.Instance.StartCoroutine(tick());
    }

    IEnumerator tick() {
        while (true) {
            yield return new WaitForEndOfFrame();
            frameIndex++;
            //SkillMgr.Instance.tick(frameIndex);
            if (luaFunc != null) {
                luaFunc.Call(frameIndex);
            }
        }
    }
}

