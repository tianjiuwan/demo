using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader
{
    public string path;
    public E_LoaderStatus loaderStatus = E_LoaderStatus.Waiting;
    private List<Action<bool,string, AssetBundle>> handlers = null;

    public Loader(string path)
    {
        this.path = path;
    }
    public Loader(string path, Action<bool, string,AssetBundle> callBack)
    {
        this.path = path;
        addHandler(callBack);
    }

    //add handler
    public void addHandler(Action<bool, string,AssetBundle> callBack)
    {
        if (handlers == null)
        {
            handlers = new List<Action<bool,string, AssetBundle>>();
        }
        handlers.Add(callBack);
    }
    //remove handler
    public void removeHandler(Action<bool, string,AssetBundle> callBack)
    {
        if (handlers != null && handlers.Contains(callBack))
        {
            handlers.Remove(callBack);
        }
    }
    //load finish
    private void onLoadFinish(AssetBundle ab)
    {
        LoaderMgr.Instance.remove(this);
        if (handlers != null)
        {
            bool isSuccess = ab != null;
            for (int i = 0; i < handlers.Count; i++)
            {
                handlers[i].Invoke(isSuccess, path,ab);
            }
        }
    }
    //加载资源 PC or Mobile
    public IEnumerator resLoad()
    {
        loaderStatus = E_LoaderStatus.Loading;
        //从缓存中获取ab
        if (AssetCacheMgr.Instance.isHas(path))
        {
            onLoadFinish(AssetCacheMgr.Instance.get(path));
            loaderStatus = E_LoaderStatus.Loading;
            yield break;
        }
        //加载ab
        AssetBundleCreateRequest req;
        //PC
        if (Application.platform == RuntimePlatform.WindowsEditor
            || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            byte[] buffer = File.ReadAllBytes(path);
            req = AssetBundle.LoadFromMemoryAsync(buffer);
            yield return req;
        }
        else
        {
            //mobile
            req = AssetBundle.LoadFromFileAsync(path);
            yield return req;
        }
        if (req.isDone)
        {
            //add to cache
            AssetCacheMgr.Instance.add(path, req.assetBundle);
            onLoadFinish(req.assetBundle);
        }
        loaderStatus = E_LoaderStatus.Loading;
    }
}
