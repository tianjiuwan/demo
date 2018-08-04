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
                GameObject go = new GameObject("PoolRoot");
                instance.PoolRoot = go.transform;
                GameObject.DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    public Transform PoolRoot;
    private Dictionary<string, BasePool> pools = new Dictionary<string, BasePool>();
    //给编辑器提供展示所有pool
    public List<BasePool> getPools()
    {
        return new List<BasePool>(pools.Values);
    }
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

    /// <summary>
    /// 回收 
    /// 可能pool已经不存在 需要释放引用
    /// </summary>
    /// <param name="obj"></param>
    public void recyle(GameObject obj)
    {
        PoolObj po = obj.GetComponent<PoolObj>();
        if (po == null)
        {
            GameObject.Destroy(obj, 0.3f);
            return;
        }
        if (!pools.ContainsKey(po.path))
        {
            List<string> stLst = po.stRefs;
            if (stLst != null)
            {
                for (int i = 0; i < stLst.Count; i++)
                {
                    AssetCacheMgr.Instance.subRef(stLst[i]);
                }
            }
            List<string> dyLst = po.getDyRefs();
            if (dyLst != null)
            {
                for (int i = 0; i < dyLst.Count; i++)
                {
                    AssetCacheMgr.Instance.subRef(dyLst[i]);
                }
            }
            AssetCacheMgr.Instance.subRef(po.path);
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

    //检查一次池子
    public void checkPools()
    {
        List<string> removeKeys = new List<string>();
        double nowTime = TimeUtils.getSecTime();
        foreach (var item in pools)
        {
            if (nowTime - item.Value.useTime > Define.checkBasePoolSec&&item.Value.canRmove())
            {
                removeKeys.Add(item.Key);
            }
        }
        if (removeKeys.Count > 0)
        {
            for (int i = 0; i < removeKeys.Count; i++)
            {
                BasePool bp = pools[removeKeys[i]];
                pools.Remove(removeKeys[i]);
                bp.dispose();
            }
        }
        Debug.Log("清理obj池子 count:  " + removeKeys.Count);
    }

    //销毁所有池子
    public void disposePools()
    {
        foreach (var item in pools)
        {
            item.Value.dispose();
        }
        pools.Clear();
    }

    public void dispose()
    {
        disposePools();
        if (this.PoolRoot != null)
        {
            GameObject.Destroy(this.PoolRoot.gameObject);
        }
    }
}
