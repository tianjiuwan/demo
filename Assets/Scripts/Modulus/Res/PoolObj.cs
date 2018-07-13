using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每一个从对象池出来的obj
/// </summary>
public class PoolObj : MonoBehaviour
{
    //obj abPath
    public string path;
    //静态依赖列表
    public List<string> stRefs = null;
    //动态依赖列表
    private List<string> dyRefs = null;
    public void addRefPath(string path)
    {
        if (dyRefs == null) {
            dyRefs = new List<string>();
        }
        //动态静态里面都不包含
        if (!dyRefs.Contains(path) && !isHas(path))
        {
            dyRefs.Add(path);
            AssetCacheMgr.Instance.addRef(path);
        }
    }
    public List<string> getDyRefs()
    {
        return dyRefs;
    }
    //静态列表是否已经包含
    private bool isHas(string key)
    {
        if (stRefs == null) return false;
        return stRefs.Contains(key);
    }

}