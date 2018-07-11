using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每一个从对象池出来的obj
/// </summary>
public class PoolObj : MonoBehaviour
{
    //obj路径 获取静态依赖列表
    public string path;

    //动态依赖列表
    private List<string> dyRefs = null;
    public void addRefPath(string path)
    {
        if (dyRefs == null)
            dyRefs = new List<string>();
        if (!dyRefs.Contains(path))
            dyRefs.Add(path);
    }
    public List<string> getDyRefs()
    {
        return dyRefs;
    }
}