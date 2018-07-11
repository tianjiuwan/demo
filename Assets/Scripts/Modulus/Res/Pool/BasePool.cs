using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BasePool
{
    public BasePool(string path)
    {
        this.path = path;
        this.name = Path.GetFileNameWithoutExtension(this.path);
    }
    private string path;
    private string name;
    private E_PoolType poolType = E_PoolType.None;
    private double useTime = 0;
    private List<Action<GameObject>> handlers = new List<Action<GameObject>>();
    private List<GameObject> cacheLst = new List<GameObject>();
    private GameObject tempObj = null;

    //获取
    public void get(Action<GameObject> callBack)
    {
        //如果tempObj是空 add handler并创建loader加载
        if (tempObj == null)
        {
            handlers.Add(callBack);
            LoaderMgr.Instance.addTask(path, onLoaderFinish);
            return;
        }
        GameObject go = null;
        //如果tempObj不是空 且 cacheLst>0 从缓存获取
        if (cacheLst.Count > 0 && callBack != null)
        {
            go = cacheLst[0];
            cacheLst.RemoveAt(0);
            callBack.Invoke(go);
            return;
        }
        //如果tempObj不是空 且cacheLst<=0 实例化
        if (callBack != null)
        {
            go = GameObject.Instantiate(tempObj);
            PoolObj po = go.AddComponent<PoolObj>();
            po.path = this.path;
            callBack.Invoke(go);
        }
    }

    //loader加载完成回调
    private void onLoaderFinish(bool isSuccess,string loaderPath, AssetBundle ab)
    {
        if (!isSuccess)
        {
            Debug.LogError("ab加载失败 path " + this.path);
            return;
        }
        UnityEngine.Object obj = ab.LoadAsset(this.name);
        tempObj = GameObject.Instantiate(obj) as GameObject;
        for (int i = 0; i < handlers.Count; i++)
        {
            GameObject go = GameObject.Instantiate(tempObj);
            PoolObj po = go.AddComponent<PoolObj>();
            po.path = this.path;
            handlers[i].Invoke(go);
        }
        handlers.Clear();
    }
    //回收
    public void recyle(GameObject obj)
    {
        this.cacheLst.Add(obj);
    }
    //中断
    public void unLoad(Action<GameObject> callBack)
    {
        if (handlers.Contains(callBack))
        {
            handlers.Remove(callBack);
        }
        LoaderMgr.Instance.unLoad(this.path, onLoaderFinish);
    }
}
