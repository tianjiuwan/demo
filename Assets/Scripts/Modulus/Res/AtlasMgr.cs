using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpriteCall
{
    public string spName;
    public Action<Sprite,string> callBack;//p1 sprite p2 abName
    public SpriteCall(string name,Action<Sprite,string> call) {
        spName = name;
        callBack = call;
    }
}

/// <summary>
/// 图集管理器
/// 对面提供方法 setImageByName(string name)//外部只需要给image名称
/// 设置image的的时候 只给了名字； 一个图集里面的icon打包成了一个ab
/// 需要先加载ab,再从ab获取sprite
/// 所以每次加入新icon,生成一次图集配置
/// key = iconName,val = abPath
/// </summary>
public class AtlasMgr
{
    private static AtlasMgr instance;
    public static AtlasMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AtlasMgr();
            }
            return instance;
        }
    }

    private Dictionary<string, string> atlasPool = new Dictionary<string, string>();
    private Dictionary<string, List<SpriteCall>> callPool = new Dictionary<string, List<SpriteCall>>();
    private const string editorPre = Define.editorPre;
    //初始化 解析图集配置
    public void initialize()
    {
        loadAtlasCfg();
    }
    void loadAtlasCfg()
    {
        string atlasPath = Path.Combine(Define.abPre, Define.atlasBundleName);
        var bundle = AssetBundle.LoadFromFile(atlasPath);
        TextAsset txt =  bundle.LoadAsset<UnityEngine.Object>("atlasCfg") as TextAsset;
        string[] cfgs = txt.text.Split('\n');
        for (int i = 0; i < cfgs.Length; i++)
        {
            if (string.IsNullOrEmpty(cfgs[i])) continue;
            string[] kv = cfgs[i].Split(':');
            if (!atlasPool.ContainsKey(kv[0]))
            {
                Uri uri = new Uri(kv[1], UriKind.RelativeOrAbsolute);
                atlasPool.Add(kv[0], uri.ToString());
            }
            else {
                Debug.LogWarning("图集有重复名称: name:  " + kv[0] + " path : " + kv[1]);
            }                  
        }
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }

    private string getAtlasPath(string icon)
    {
        if (atlasPool.ContainsKey(icon)) {
            return atlasPool[icon];
        }
        return null;
    }

    //对外接口
    public void setImageByName(string name, Action<Sprite,string> callBack)
    {
        string key = getAtlasPath(name);
        if (string.IsNullOrEmpty(key)) {
            Debug.LogError("sprite不存在图集中 请重新导出图集配置 " + name);
            return;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            //编辑器下面是否加载整个图集文件夹 缓存？todo
            string path = Path.Combine(Application.dataPath, Define.editorPre);
             path = Path.Combine(path, key);
            path = Path.Combine(path, name+".png");
            callBack(AssetDataBaseMgr.load<Sprite>(path), key);
            return;
        }
       
        if (AssetCacheMgr.Instance.isHas(key))
        {
            PackAsset pka = AssetCacheMgr.Instance.get(key);
            if (callBack != null)
                callBack.Invoke(pka.getObj<Sprite>(name), key);
            return;
        }
        //需要加载图集ab     
        if (!callPool.ContainsKey(key))
        {
            callPool.Add(key, new List<SpriteCall>());
        }
        callPool[key].Add(new SpriteCall(name,callBack));
        LoaderMgr.Instance.addTask(key, onLoadFinish);
    }

    //加载ab完成
    //name = abPath
    //
    private void onLoadFinish(bool isSuccess, string name, PackAsset pka)
    {
        if (isSuccess)
        {
            if (callPool.ContainsKey(name))
            {
                List<SpriteCall> handlers = callPool[name];                
                for (int i = 0; i < handlers.Count; i++)
                {
                    Sprite sp = pka.getObj<Sprite>(handlers[i].spName);
                    handlers[i].callBack.Invoke(sp, atlasPool[sp.name]);
                }
                callPool[name].Clear();
                callPool.Remove(name);
            }
        }
        else
        {
            Debug.LogError("加载失败");
        }
    }

}

