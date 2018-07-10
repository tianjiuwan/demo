using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池 管理类
/// </summary>
public class PoolMgr
{
    private static PoolMgr instance;
    public static PoolMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolMgr();
            }
            return instance;
        }
    }
    private Dictionary<string, BasePool> pools = new Dictionary<string, BasePool>();
    //获取
    public void get(string path, Action<GameObject> callBack)
    {
        if (!pools.ContainsKey(path))
        {
            BasePool bp = new BasePool(path);
            pools.Add(path, bp);
        }
        pools[path].get(callBack);
    }
    //回收
    public void recyle(GameObject obj)
    {
        PoolObj po = obj.GetComponent<PoolObj>();
        if (po == null || !pools.ContainsKey(po.path))
        {
            GameObject.Destroy(obj, 0.3f);
            return;
        }
        pools[po.path].recyle(obj);
    }
    //中断
    public void unLoad(string path, Action<GameObject> callBack)
    {
        if (pools.ContainsKey(path))
        {
            pools[path].unLoad(callBack);
        }
    }

}
