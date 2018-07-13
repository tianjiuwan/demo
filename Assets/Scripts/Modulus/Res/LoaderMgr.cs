using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载管理器
/// </summary>
public class LoaderMgr : MonoBehaviour
{
    private static LoaderMgr instance;
    public static LoaderMgr Instance
    {
        get
        {
            if (instance == null) {
                GameObject go = GameObject.Find("LoaderMgr");
                if (go == null)
                {
                    go = new GameObject("LoaderMgr");
                    instance = go.AddComponent<LoaderMgr>();
                    GameObject.DontDestroyOnLoad(go);
                }
                else
                {
                    instance = go.GetComponent<LoaderMgr>();
                }
            }            
            return instance;
        }
    }
    public void initialize()
    {

    }
    //存一个loader字典
    private Dictionary<string, Loader> loaderPool = new Dictionary<string, Loader>();
    //存一个loader队列
    private Queue<Loader> loaderQueue = new Queue<Loader>();
    //获取queue数量
    public int getQueueCount() {
        return loaderQueue.Count;
    }

    //添加一个loader
    public void addTask(string path, Action<bool, string, PackAsset> callBack)
    {
        if (loaderPool.ContainsKey(path))
        {
            loaderPool[path].addHandler(callBack);
            return;
        }
        //获取ab所有依赖 先把依赖加入加载列表
        List<string> deps = new List<string>();
        ManifsetMgr.Instance.getDeps(path,ref deps);
        for (int i = 0; i < deps.Count; i++)
        {
            if (!AssetCacheMgr.Instance.isHas(deps[i]))
            {
                addTask(deps[i], null);
            }
        }
        Loader loader = new Loader(path, callBack);
        loaderPool.Add(path, loader);
        loaderQueue.Enqueue(loader);
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
    public void unLoad(string path, Action<bool, string, PackAsset> callBack)
    {
        if (loaderPool.ContainsKey(path))
        {
            loaderPool[path].removeHandler(callBack);
        }
    }


    private float checkCacheSec = 10;
    private float lastCheckTime = 0;
    //暂时用mono update tick
    private void Update()
    {
        if (Time.timeSinceLevelLoad - lastCheckTime >= checkCacheSec) {
            AssetCacheMgr.Instance.doCheck();
            lastCheckTime = Time.timeSinceLevelLoad;
        }
        if (this.loaderQueue.Count <= 0) return;
        Loader loader = this.loaderQueue.Peek();
        if (loader.loaderStatus == E_LoaderStatus.Waiting) AssetCoroutine.Instance.doLoad(loader);
        if (loader.loaderStatus == E_LoaderStatus.Loading) return;
        if (loader.loaderStatus == E_LoaderStatus.Finish)
        {
            string key = loader.path;
            if (this.loaderPool.ContainsKey(key)) this.loaderPool.Remove(key);
            this.loaderQueue.Dequeue();
        }
    }

}
