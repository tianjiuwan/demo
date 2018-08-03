using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Loader
{
    public string path;
    public E_LoaderStatus loaderStatus = E_LoaderStatus.Waiting;
    private List<Action<bool, string, PackAsset>> handlers = null;

    public Loader(string path)
    {
        this.path = path;
    }
    public Loader(string path, Action<bool, string, PackAsset> callBack)
    {
        this.path = path;
        addHandler(callBack);
    }

    //add handler
    public void addHandler(Action<bool, string, PackAsset> callBack)
    {
        if (handlers == null)
        {
            handlers = new List<Action<bool, string, PackAsset>>();
        }
        handlers.Add(callBack);
    }
    //remove handler
    public void removeHandler(Action<bool, string, PackAsset> callBack)
    {
        if (handlers != null && handlers.Contains(callBack))
        {
            handlers.Remove(callBack);
        }
    }
    //load finish
    private void onLoadFinish(PackAsset pka)
    {
        LoaderMgr.Instance.remove(this);
        if (handlers != null)
        {
            bool isSuccess = pka != null;
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i] != null)
                {
                    handlers[i].Invoke(isSuccess, path, pka);
                }
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
            loaderStatus = E_LoaderStatus.Finish;
            yield break;
        }
        PackAsset pka = null;
        //PC
#if DEVELOP
            string assetPath = Path.Combine(Define.editorPre, path + ".prefab");
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            yield return obj;
            pka = new PackAsset(path, obj);        
#else        
            //mobile            
            string assetPath = Path.Combine(Define.abPre,this.path);
            AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(assetPath);
            yield return req;
            pka = new PackAsset(path, req.assetBundle);        
#endif
        //add to cache
        AssetCacheMgr.Instance.add(path, pka);
        onLoadFinish(pka);
        loaderStatus = E_LoaderStatus.Finish;
    }
}
