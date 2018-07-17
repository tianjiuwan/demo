using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    void Start()
    {
        LogicFrame.Instance.initialize();
        LoaderMgr.Instance.initialize();
        ManifsetMgr.Instance.initislize();
        AtlasMgr.Instance.initialize();
    }

  

}
