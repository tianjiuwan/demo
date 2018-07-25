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
    public Transform Target;

    //void LateUpdate()
    //{
    //    Quaternion rotation = Quaternion.Euler(0f, 30f, 0f) * Target.rotation;
    //    Vector3 newPos = rotation * new Vector3(10f, 0f, 0f);
    //    Debug.DrawLine(newPos, Vector3.zero, Color.red);
    //    Debug.Log("newpos " + newPos + " nowpos " + Target.position + " distance " + Vector3.Distance(newPos, Target.position));
    //}


    private void OnDrawGizmos()
    {
        if (Target == null) return;
        //Vector3 pos = obj.transform.position + obj.transform.forward * 6;
        //Gizmos.DrawCube(pos, Vector3.one * 0.5f);

        Gizmos.DrawLine(Target.position, Target.forward*10+Target.position);
        Quaternion rot = Quaternion.Euler(0, 30, 0) * Target.rotation;
        Vector3 pos = rot * new Vector3(10,0,10)+Target.position;
        Gizmos.DrawLine(Target.position, pos);
        //Gizmos.DrawLine(Target.position, Target.forward);
    }
}

