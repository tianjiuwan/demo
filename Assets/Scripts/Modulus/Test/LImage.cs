using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LImage : MonoBehaviour
{

    private PoolObj rootObj = null;

    private void Start()
    {
        Button btn = this.gameObject.AddComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() =>
            {
                Image img = this.gameObject.GetComponent<Image>();
                if (img != null)
                {
                    AtlasMgr.Instance.setImageByName("KFSJ_1", (sp, abName) =>
                    {
                        img.sprite = sp;
                        //增加引用
                        addRef(abName);
                    });
                }
            });
        }
    }

    private void addRef(string abName) {
        if (this.rootObj == null) {
            findPoolRoot(this.transform);
        }
        this.rootObj.addRefPath(abName);
    }

    private void findPoolRoot(Transform trans) {
        if (trans == null) return;
        if (trans.GetComponent<PoolObj>() == null)
        {
            findPoolRoot(trans.parent);
        }
        else {
            this.rootObj = trans.GetComponent<PoolObj>();
        }
    }
}

