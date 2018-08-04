using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 基础gameobject池子
/// modelPool应该重写回收方法和getObj方法(禁用和启用animator)
/// 其他池子根据需求
/// </summary>
public class BasePool
{
    public BasePool(string path)
    {
        this.path = path;
        this.name = Path.GetFileNameWithoutExtension(this.path);
        string poolName = string.Format("[{0}][{1}][{2}]", poolType.ToString(), name, path);
        GameObject go = new GameObject(poolName);
        this.poolRoot = go.transform;
        this.poolRoot.SetParent(PoolMgr.Instance.PoolRoot);
        this.poolRoot.transform.localPosition = Vector3.zero;
        ManifsetMgr.Instance.getDeps(this.path,ref depends);
    }
    private Transform poolRoot;
    private List<string> depends = new List<string>();
    private string path;
    private string name;
    public string Name {
        get {
            return this.name;
        }
    }
    private E_PoolType poolType = E_PoolType.None;
    public string PoolType {
        get {
            return poolType.ToString();
        }
    }
    public double useTime = 0;
    private List<Action<GameObject>> handlers = new List<Action<GameObject>>();
    private List<GameObject> cacheLst = new List<GameObject>();
    public int CacheCount {
        get {
            return cacheLst.Count;
        }
    }
    public int HandlerCount {
        get {
            return handlers.Count;
        }
    }

    //获取
    public void get(Action<GameObject> callBack)
    {
        //如果有这个ab
        if (!AssetCacheMgr.Instance.isHas(this.path))
        {
            handlers.Add(callBack);
            LoaderMgr.Instance.addTask(path, onLoaderFinish);
            return;
        }
        else {
            callBack.Invoke(getObj());
        }
    }

    //loader加载完成回调
    private void onLoaderFinish(bool isSuccess,string loaderPath, PackAsset pka)
    {
        if (!isSuccess)
        {
            Debug.LogError("ab加载失败 path " + this.path);
            return;
        }
        if (handlers.Count > 0) {
            for (int i = 0; i < handlers.Count; i++)
            {
                //handlers[i].Invoke(getObj());
                getObj(handlers[i]);
            }            
        }
    }

    //同步loadAsset
    private GameObject getObj() {
        GameObject go = null;
        //且 cacheLst>0 从缓存获取
        if (cacheLst.Count > 0)
        {
            go = cacheLst[0];
            cacheLst.RemoveAt(0);
        }
        else {
            //来这里一定可以获取到PackAsset
            PackAsset pka = AssetCacheMgr.Instance.get(this.path);
            go = GameObject.Instantiate(pka.Obj)as GameObject;            
            PoolObj po = go.AddComponent<PoolObj>();
            po.path = this.path;
            po.stRefs = this.depends;
            addRef();
        }
        //更新一下使用时间
        this.useTime = TimeUtils.getSecTime();
        return go;
    }

    //异步loadAsset
    private void getObj(Action<GameObject> callBack) {
        GameObject go = null;
        //且 cacheLst>0 从缓存获取
        if (cacheLst.Count > 0)
        {
            go = cacheLst[0];
            cacheLst.RemoveAt(0);
            callBack(go);
            this.handlers.Remove(callBack);
        }
        else
        {
            PackAsset pka = AssetCacheMgr.Instance.get(this.path);
            AssetCoroutine.Instance.StartCoroutine(pka.getObjAsync(insObj, callBack));
        }
        //更新一下使用时间
        this.useTime = TimeUtils.getSecTime();
    }
    private void insObj(UnityEngine.Object obj,Action<GameObject> callBack) {
        GameObject go = GameObject.Instantiate(obj) as GameObject;
        PoolObj po = go.AddComponent<PoolObj>();
        po.path = this.path;
        po.stRefs = this.depends;
        addRef();
        callBack(go);
        this.handlers.Remove(callBack);
        this.useTime = TimeUtils.getSecTime();
    }

    //回收
    public void recyle(GameObject obj)
    {
        this.cacheLst.Add(obj);
        obj.transform.SetParent(this.poolRoot);
        obj.transform.localPosition = Vector3.zero;
    }
    //中断
    public void unLoad(Action<GameObject> callBack)
    {
        if (handlers.Contains(callBack))
        {
            handlers.Remove(callBack);
        }
       //LoaderMgr.Instance.unLoad(this.path, onLoaderFinish);
    }
    //实例化一个obj调用一次add ref 静态引用
    private void addRef() {
        for (int i = 0; i < depends.Count; i++)
        {
            AssetCacheMgr.Instance.addRef(depends[i]);
        }
        AssetCacheMgr.Instance.addRef(this.path);
    }
    //销毁pool obj 静态引用
    private void subRef()
    {
        for (int i = 0; i < depends.Count; i++)
        {
            AssetCacheMgr.Instance.subRef(depends[i]);
        }
        AssetCacheMgr.Instance.subRef(this.path);
    }
    //销毁池子
    public void dispose() {
        this.handlers.Clear();
        for (int i = 0; i < cacheLst.Count; i++)
        {
            destroyObj(cacheLst[i]);
        }
        cacheLst.Clear();
        cacheLst = null;
        GameObject.Destroy(this.poolRoot.gameObject, 0.3f);
    }
    //销毁一个obj 释放静态和动态引用
    private void destroyObj(GameObject obj) {
        if (obj != null) {
            subRef();
            PoolObj po = obj.GetComponent<PoolObj>();
            if (po != null&& po.getDyRefs()!=null) {
                List<string> dyRef = po.getDyRefs();
                for (int i = 0; i < dyRef.Count; i++)
                {
                    AssetCacheMgr.Instance.subRef(dyRef[i]);
                }
            }
            GameObject.Destroy(obj, 0.3f);
        }
    }


    //是否能够移除
    public bool canRmove() {
        return this.handlers.Count <= 0;
    }

}
