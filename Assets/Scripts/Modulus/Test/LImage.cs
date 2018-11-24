using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Image动态设置sprite addRef
/// 动态设置sprite的时候释放上一个ref
/// 大UI进入池子也释放ref
/// 这里的ref只针对动态ref
/// </summary>
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
                    PoolMgr.Instance.getObj("TFJH_change", (sp,resName) =>
                    {
                        img.sprite = sp;
                        addRef(resName);
                    });
                }
            });
        }
    }

    private void addRef(string abName) {
        if (this.rootObj == null) {
            findPoolRoot(this.transform);
        }
        this.rootObj.addDeps(abName);
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

