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
    private double useTime = 0;
    private List<Action<GameObject>> handlers = new List<Action<GameObject>>();
    private List<GameObject> cacheLst = new List<GameObject>();
    public int CacheCount {
        get {
            return cacheLst.Count;
        }
    }
    private GameObject tempObj = null;
    public int TempCount {
        get {
            return tempObj == null ? 0 : 1;
        }
    }

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
        //如果tempObj不是空 
        callBack.Invoke(getObj());
    }

    //loader加载完成回调
    private void onLoaderFinish(bool isSuccess,string loaderPath, PackAsset pka)
    {
        if (!isSuccess)
        {
            Debug.LogError("ab加载失败 path " + this.path);
            return;
        }
        tempObj = GameObject.Instantiate(pka.Obj) as GameObject;        
        tempObj.transform.SetParent(this.poolRoot);
        tempObj.transform.localPosition = Vector3.zero;
        addRef();
        for (int i = 0; i < handlers.Count; i++)
        {            
            handlers[i].Invoke(getObj());
        }
        handlers.Clear();
    }

    private GameObject getObj() {
        GameObject go = null;
        //且 cacheLst>0 从缓存获取
        if (cacheLst.Count > 0)
        {
            go = cacheLst[0];
            cacheLst.RemoveAt(0);
        }
        else {
            //如果tempObj不是空 且cacheLst<=0 实例化
            go = GameObject.Instantiate(tempObj);            
            PoolObj po = go.AddComponent<PoolObj>();
            po.path = this.path;
            addRef();
        }
        return go;
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
        LoaderMgr.Instance.unLoad(this.path, onLoaderFinish);
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
        destroyObj(this.tempObj);
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

}
