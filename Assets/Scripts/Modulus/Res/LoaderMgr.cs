using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载管理器
/// </summary>
public class LoaderMgr
{
    private static LoaderMgr instance;
    public static LoaderMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoaderMgr();
            }
            return instance;
        }
    }
    private Dictionary<string, Loader> loaderPool = new Dictionary<string, Loader>();
    //添加一个loader
    public void addTask(string path, Action<bool, string,AssetBundle> callBack)
    {
        if (loaderPool.ContainsKey(path))
        {
            loaderPool[path].addHandler(callBack);
            return;
        }
        //获取ab所有依赖 先把依赖加入加载列表 todo
        AssetBundleManifest assetBundleManifest = null;//初始化获取依赖 todo
        string[] deps = assetBundleManifest.GetAllDependencies(path);
        for (int i = 0; i < deps.Length; i++)
        {
            if (!AssetCacheMgr.Instance.isHas(deps[i]))
            {
                addTask(deps[i], null);
            }
        }
        Loader loader = new Loader(path, callBack);
        loaderPool.Add(path, loader);
    }
    //加载完毕移除loader
    public void remove(Loader loader)
    {
        if (loaderPool.ContainsKey(loader.path))
        {
            loaderPool.Remove(loader.path);
        }
    }
    //中断
    public void unLoad(string path, Action<bool,string, AssetBundle> callBack)
    {
        if (loaderPool.ContainsKey(path))
        {
            loaderPool[path].removeHandler(callBack);
        }
    }
}
