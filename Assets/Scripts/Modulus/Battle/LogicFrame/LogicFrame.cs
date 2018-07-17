using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
    public void initialize()
    {
        //if (frameTick != null) return;
        //frameTick = new Thread(startThread);
        AssetCoroutine.Instance.StartCoroutine(tick());
    }

    IEnumerator tick() {
        while (true) {
            yield return new WaitForEndOfFrame();
            frameIndex++;
            SkillMgr.Instance.tick(frameIndex);
        }
    }
}

