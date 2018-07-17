using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 外部调用 资源获取
/// </summary>
public class ResMgr
{
    private static ResMgr instance;
    public static ResMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResMgr();
            }
            return instance;
        }
    }
    //获取 暂时依赖外部给路径
    public void get(string path, Action<GameObject> callBack, E_LoadType loadType = E_LoadType.None)
    {
        PoolMgr.Instance.get(path, callBack);
    }
    //回收
    public void recyle(GameObject obj)
    {
        PoolMgr.Instance.recyle(obj);
    }
    //中断
    public void unLoad(string path, Action<GameObject> callBack)
    {
        PoolMgr.Instance.unLoad(path, callBack);
    }
    //销毁
    public void destroy(GameObject obj)
    {
        GameObject.Destroy(obj, 0.3f);
    }

    private string getPath(string name,E_LoadType loadType) {
        string path = "";
        switch (loadType) {
            case E_LoadType.None:
                break;
            case E_LoadType.UI:
                Path.Combine("assetbundle/prefabs/ui", name);
                break;
            case E_LoadType.Model:
                break;
            default:
                break;
        }
        return path;
    }

    public void tick() {
        Debug.Log("zz");
    }

}

