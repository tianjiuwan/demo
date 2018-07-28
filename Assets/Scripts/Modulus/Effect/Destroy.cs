using UnityEngine;
using System.Collections;
using System;

public class Destroy : MonoBehaviour {

	public float lifetime = 2.0f;

	void OnEnable()
	{
        TimerMgr.addSecHandler(Mathf.CeilToInt(lifetime), null, (val) =>
        {
            ResMgr.Instance.recyle(this.gameObject);
        });
	}


}
