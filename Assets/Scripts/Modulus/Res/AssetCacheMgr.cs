using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AssetBundle Cache Mgr
/// </summary>
public class AssetCacheMgr
{
    private static AssetCacheMgr instance;
    public static AssetCacheMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AssetCacheMgr();
            }
            return instance;
        }
    }
    private Dictionary<string, AssetBundle> cachePool = new Dictionary<string, AssetBundle>();
    //add
    public void add(string name, AssetBundle ab)
    {
        if (cachePool.ContainsKey(name))
        {
            Debug.LogError("重复创建了ab " + name);
            return;
        }
        cachePool.Add(name, ab);
    }
    //get
    public AssetBundle get(string name)
    {
        return cachePool[name];
    }
    //isHas
    public bool isHas(string name)
    {
        return cachePool.ContainsKey(name);
    }

}
