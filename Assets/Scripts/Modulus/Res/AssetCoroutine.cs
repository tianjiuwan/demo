using System;
using System.Collections.Generic;
using UnityEngine;

public class AssetCoroutine : MonoBehaviour
{
    private static AssetCoroutine instance;
    public static AssetCoroutine Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("AssetCoroutine");
                if (go == null)
                {
                    go = new GameObject("AssetCoroutine");                    
                    instance = go.AddComponent<AssetCoroutine>();
                    GameObject.DontDestroyOnLoad(go);
                }
                else {
                    instance = go.GetComponent<AssetCoroutine>();
                }
            }
            return instance;
        }
    }

    public void doLoad(Loader loader)
    {
        StartCoroutine(loader.resLoad());
    }

}
