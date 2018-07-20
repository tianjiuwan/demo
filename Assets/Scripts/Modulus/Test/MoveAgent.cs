using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MoveAgent : MonoBehaviour
{


    void moveTo(Vector3 dir, float dis)
    {
        dir = dir.normalized;
        this.transform.Translate(dir);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            moveTo(new Vector3(0.5f, 0, -0.3f), 2f);
        }


    }

  /*FSM只用来做位移
 * 击退
 * 浮空
 * 
 */

}

