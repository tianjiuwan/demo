using System;
using System.Collections.Generic;

/// <summary>
/// 事件派发
/// </summary>
public class EventMgr
{
    //存一个没有参数的回调 测试
    public Dictionary<string, List<Action>> eventPool = new Dictionary<string, List<Action>>();

    public void addListener(string cmd, Action handler)
    {

    }
    public void dispatch(string cmd)
    {

    }


}

