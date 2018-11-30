using UnityEngine;
using System;
public class SocketThread : MonoBehaviour
{
    private const string Tag = "_socketThread";
    private static SocketThread _instance;
    private static int mainThread;
    public static SocketThread Instance
    {
        get
        {
            if (_instance == null)
            {
                initilize();
            }
            return _instance;
        }
    }

    private Action _updateHandle = null;

    private bool _isInit = false;

    void Update()
    {
        if (_isInit && _updateHandle != null)
        {
            _updateHandle.Invoke();
        }
    }

    public void Run()
    {
        _isInit = true;
    }

    public void Stop()
    {
        _isInit = false;
    }


    public void setHandle(Action updateHandle)
    {
        _updateHandle = updateHandle;
        Run();
    }
    public static bool isMainThread()
    {
        return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThread;
    }
    public static void initilize(Action updateHandle = null)
    {
        if (_instance != null)
        {
            return;
        }
        mainThread = System.Threading.Thread.CurrentThread.ManagedThreadId;
        GameObject obj = GameObject.Find(Tag);
        if (obj == null)
        {
            obj = new GameObject();
            obj.name = Tag;
        }
        _instance = obj.GetComponent<SocketThread>();
        if (_instance == null)
        {
            _instance = obj.AddComponent<SocketThread>();
        }
        _instance.setHandle(updateHandle);
        GameObject.DontDestroyOnLoad(obj);
    }
    public static void Release()
    {
        if (!isMainThread())
        {
            return;
        }
        if (null == _instance)
        {
            return;
        }
        GameObject.Destroy(_instance.gameObject);
        _instance = null;
    }
}

