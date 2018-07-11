using System;
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

    AssetBundleManifest assetBundleManifest = null;//初始化获取依赖 todo

    //初始化ab依赖
    public void initislize() {
         
    }

}

