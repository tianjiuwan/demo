using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

public class AssetCacheWindow : EditorWindow
{

    private static AssetCacheWindow _instance = null;
    private bool isInit = false;

    [MenuItem("ToolsWindow/查看AB缓存")]
    public static void showWindow()
    {
        if (_instance == null)
        {
            _instance = (AssetCacheWindow)EditorWindow.GetWindow(typeof(AssetCacheWindow), false, "查看AB缓存", true);
            _instance.maxSize = new Vector2(1280, 720);
            GUIContent content = new GUIContent();
            content.text = "查看AB缓存";
            _instance.titleContent = content;
            _instance.isInit = true;
        }
    }

    private Vector2 scrollPos = Vector2.zero;
    private Vector2 poolPos = Vector3.zero;
    private List<GameObject> testLoadObjs = new List<GameObject>();
    private GameObject uiRoot;
    private void OnGUI()
    {
        if (!isInit) return;
        if (!Application.isPlaying) {
            testLoadObjs.Clear();
            return;
        } 
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();
        if (GUILayout.Button("实例化一个TestUI", GUILayout.Width(150), GUILayout.Height(30)))
        {
            ResMgr.Instance.get(@"AssetBundle\Prefabs\ui\TestUI", (go) =>
            {
                go.transform.SetParent(null);
                go.transform.position = Vector3.zero;
                testLoadObjs.Add(go);
                if (uiRoot == null)
                     uiRoot = GameObject.Find("grid");
                if (uiRoot != null)
                {
                    go.transform.SetParent(uiRoot.transform);
                    go.transform.localPosition = Vector3.zero;
                }
            });
        }
        GUILayout.Space(10);
        if (GUILayout.Button("销毁一个TestUI: " + testLoadObjs.Count, GUILayout.Width(150), GUILayout.Height(30)))
        {
            if (testLoadObjs.Count > 0)
            {
                GameObject go = testLoadObjs[0];
                testLoadObjs.RemoveAt(0);
                ResMgr.Instance.recyle(go);
            }
        }
        GUILayout.Space(10);
        if (GUILayout.Button("实例化一个role_superman", GUILayout.Width(220), GUILayout.Height(30)))
        {
            ResMgr.Instance.get(@"AssetBundle\Prefabs\model\role_superman\model\role_superman", (go) =>
            {
                go.transform.SetParent(null);
                go.transform.position = Vector3.zero;
            });
        }
        GUILayout.Space(10);
        GUILayout.EndVertical();
        GUILayout.Space(20);
        if (GUILayout.Button("销毁所有池子", GUILayout.Width(150), GUILayout.Height(30)))
        {
            PoolMgr.Instance.disposePools();
        }
        GUILayout.Space(20);
        if (GUILayout.Button("卸载所有AB", GUILayout.Width(150), GUILayout.Height(30)))
        {
            AssetCacheMgr.Instance.unloadAllAssetBundle(true);
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Time: " + System.DateTime.Now);
        GUILayout.BeginHorizontal(GUILayout.Width(600), GUILayout.Height(60));
        GUILayout.Space(20);
        GUIContent titleContent = new GUIContent();
        titleContent.text = "等待加载数量: " + LoaderMgr.Instance.getQueueCount();
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 22;
        GUILayout.Label(titleContent, titleStyle, GUILayout.Width(600), GUILayout.Height(60));
        GUILayout.EndHorizontal();
        //绘制2个滑动框
        GUILayout.BeginHorizontal();
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(600), GUILayout.Height(600));
        List<PackAsset> lst = AssetCacheMgr.Instance.getAll();
        for (int i = 0; i < lst.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(20);
            StringBuilder builder = new StringBuilder();
            builder.Append("AssetBundleName: ");
            builder.Append(lst[i].name);
            GUIContent content = new GUIContent();
            content.text = builder.ToString();
            GUIStyle style = new GUIStyle();
            style.fontSize = 14;
            GUILayout.Box(content, style, GUILayout.Width(360), GUILayout.Height(40));
            style.fontSize = 20;
            content.text = "RefCount: " + lst[i].refCount;
            GUILayout.Box(content, style, GUILayout.Width(100), GUILayout.Height(40));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
        poolPos = GUILayout.BeginScrollView(poolPos, false, true, GUILayout.Width(600), GUILayout.Height(600));
        List<BasePool> pools = PoolMgr.Instance.getPools();
        for (int i = 0; i < pools.Count; i++)
        {
            BasePool bp = pools[i];
            GUILayout.BeginHorizontal();
            GUILayout.Label("PoolName: " + bp.Name, GUILayout.Width(160), GUILayout.Height(30));
            GUILayout.Label("PoolType: " + bp.PoolType, GUILayout.Width(100), GUILayout.Height(30));
            GUILayout.Label("CacheCount: " + bp.CacheCount, GUILayout.Width(100), GUILayout.Height(30));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
        GUILayout.EndHorizontal();
        //结束绘制2个滑动框
        GUILayout.EndVertical();
    }
}
