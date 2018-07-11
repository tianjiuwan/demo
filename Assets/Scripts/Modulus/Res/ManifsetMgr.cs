using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManifsetMgr
{
    private static ManifsetMgr instance;
    public static ManifsetMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ManifsetMgr();
            }
            return instance;
        }
    }

    private string manifestPath = Define.abPre + "AssetBundleExport";
    AssetBundleManifest assetBundleManifest = null;//初始化获取依赖 todo

    //初始化ab依赖
    public void initislize()
    {
        loadManifest();
    }
    void loadManifest()
    {
        //LoadFromFile不可以有.assetbundle后缀
        var bundle = AssetBundle.LoadFromFile(manifestPath);
        assetBundleManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }

    IEnumerator doLoad()
    {
        //LoadFromFile不可以有.assetbundle后缀
        var bundle = AssetBundle.LoadFromFile(manifestPath);
        yield return bundle;
        assetBundleManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }

    public void getDeps(string name, ref List<string> lst)
    {
        if (Instance.assetBundleManifest == null) return;
        name = name.ToLower();
        if (Instance.assetBundleManifest != null)
        {
            string[] deps = Instance.assetBundleManifest.GetAllDependencies(name);
            for (int i = 0; i < deps.Length; i++)
            {
                lst.Add(deps[i]);
            }
        }
    }

    public void dispose() {

    }
}

