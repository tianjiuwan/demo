using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 封装一层asset
/// 做一下引用计数
/// 添加count: 从资源中获取obj
/// 移除count: poolObj销毁的时候 减少count todo
/// </summary>
public class PackAsset
{
    public int refCount = 0;
    private UnityEngine.Object obj = null;
    private AssetBundle ab = null;
    private string abName;
    public string name
    {
        get
        {
            return this.abName;
        }
    }
    private string abPath;
    public string path
    {
        get
        {
            return this.abPath;
        }
    }
    public PackAsset(string path, AssetBundle ab)
    {
        this.abPath = path;
        this.abName = Path.GetFileNameWithoutExtension(path);
        this.ab = ab;
    }
    public PackAsset(string path, UnityEngine.Object obj)
    {
        this.abPath = path;
        this.obj = obj;
    }

    /// <summary>
    /// 获取main asset
    /// </summary>
    public UnityEngine.Object Obj
    {
        get
        {
            if (obj == null)
            {
                obj = ab.LoadAsset(this.abName);
            }
            return obj;
        }
    }
    /// <summary>
    /// 根据类型获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T getObj<T>(string name) where T : UnityEngine.Object
    {
        return this.ab.LoadAsset<T>(name);
    }

    public void addRefCount()
    {
        refCount++;
    }
    public void subRefCount()
    {
        refCount--;
    }

    /// <summary>
    /// 释放ab
    /// 是否卸载所有loaded根据refCount判断
    /// 卸载完成需要从cache中移除
    /// </summary>
    /// <param name="isAllLoaded"></param>
    public void unload()
    {
        bool isUnloadAll = refCount <= 0;
        if (this.ab != null)
        {
            this.ab.Unload(isUnloadAll);            
            if (!isUnloadAll)
                Resources.UnloadUnusedAssets();
        }
    }
    /// <summary>
    /// check的时候 只有在引用计数小于0 才会释放ab
    /// </summary>
    /// <returns></returns>
    public bool doCheck()
    {
        bool isUnloadAll = refCount <= 0;
        if (this.ab != null&& isUnloadAll)
        {
            this.ab.Unload(isUnloadAll);
        }
        return isUnloadAll;
    }
}

