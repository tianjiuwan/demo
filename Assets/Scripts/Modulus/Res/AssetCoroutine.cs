using System;
using System.Collections.Generic;
using UnityEngine;

public class AssetCoroutine : MonoBehaviour
{
    public void doLoad(Loader loader)
    {
        StartCoroutine(loader.resLoad());
    }

}
