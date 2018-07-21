using System;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    Event e = null;

    private static InputMgr instance;
    public static InputMgr Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("InputMgr");
                if (go == null)
                {
                    go = new GameObject("InputMgr");
                    instance = go.AddComponent<InputMgr>();
                    GameObject.DontDestroyOnLoad(go);
                }
                else
                {
                    instance = go.GetComponent<InputMgr>();
                }
            }
            return instance;
        }
    }

    public void initialize()
    {

    }

    private event Action<KeyCode> keyDownListener;
    public void addListener(Action<KeyCode> handler)
    {
        keyDownListener += handler;
    }
    public void removeListener(Action<KeyCode> handler)
    {
        keyDownListener -= handler;
    }

    private void OnGUI()
    {
        e = Event.current;
        if (e == null) return;
        if (e.isKey)
        {
            KeyCode code = e.keyCode;
            if (e.type == EventType.KeyDown)
            {
                if (keyDownListener != null) {
                    keyDownListener(code);
                }
            }
        }
    }
}

