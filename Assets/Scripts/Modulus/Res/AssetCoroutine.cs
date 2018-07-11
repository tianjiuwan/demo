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
                GameObject go = new GameObject("AssetCoroutine");
                instance = go.AddComponent<AssetCoroutine>();
            }
            return instance;
        }
    }

    public void doLoad(Loader loader)
    {
        StartCoroutine(loader.resLoad());
    }

}
