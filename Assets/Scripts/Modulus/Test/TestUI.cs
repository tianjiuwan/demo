using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{

    public GameObject obj;

    private void Update()
    {


    }


    private void OnDrawGizmos()
    {
        if (obj == null) return;
        Vector3 pos = obj.transform.position + obj.transform.forward * 6;
        Gizmos.DrawCube(pos,Vector3.one*0.5f);
    }
}

