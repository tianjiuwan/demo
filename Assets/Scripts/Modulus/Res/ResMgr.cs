using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 外部调用 资源获取
/// </summary>
public class ResMgr
{
    //获取
    public void get(string path, Action<GameObject> callBack)
    {
        PoolMgr.Instance.get(path, callBack);
    }
    //回收
    public void recyle(GameObject obj)
    {
        PoolMgr.Instance.recyle(obj);
    }
    //中断
    public void unLoad(string path, Action<GameObject> callBack)
    {
        PoolMgr.Instance.unLoad(path, callBack);
    }
    //销毁
    public void destroy(GameObject obj)
    {
        GameObject.Destroy(obj, 0.3f);
    }
}

