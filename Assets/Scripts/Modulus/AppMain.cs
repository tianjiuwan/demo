using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour {


	void Start () {
        LoaderMgr.Instance.initialize();
        ResMgr.Instance.get(@"AssetBundle\Prefabs\ui\TestUI", (go) =>
        {
            go.transform.position = Vector3.zero;
        });
    }
	

}
