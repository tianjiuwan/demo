using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{


    void Start()
    {
        LoaderMgr.Instance.initialize();
        ManifsetMgr.Instance.initislize();
        AtlasMgr.Instance.initialize();
    }


    private void OnApplicationQuit()
    {

    }

}
