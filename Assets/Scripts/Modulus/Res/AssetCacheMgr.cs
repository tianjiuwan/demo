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
    private Dictionary<string, PackAsset> cachePool = new Dictionary<string, PackAsset>();

    //主要提供给编辑器查看
    public List<PackAsset> getAll() {
        return new List<PackAsset>(cachePool.Values);
    }
    //add name = path 
    public void add(string name, PackAsset passet)
    {
        if (cachePool.ContainsKey(name))
        {
            Debug.LogError("重复创建了ab " + name);
            return;
        }
        cachePool.Add(name, passet);
    }
    //get
    public PackAsset get(string name)
    {
        return cachePool[name];
    }
    //isHas
    public bool isHas(string name)
    {
        return cachePool.ContainsKey(name);
    }
    //add ref
    public void addRef(string key) {
        if (cachePool.ContainsKey(key)) {
            cachePool[key].addRefCount();
        }
    }
    //sub ref
    public void subRef(string key)
    {
        if (cachePool.ContainsKey(key))
        {
            cachePool[key].subRefCount();
        }
    }

    //释放所有ab
    public void unloadAllAssetBundle(bool isAllLoaded=false) {
        foreach (var item in cachePool)
        {
              item.Value.unload();
        }
        cachePool.Clear();   
    }

    
}
