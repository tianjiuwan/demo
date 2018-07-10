using System;
using System.Collections.Generic;
using UnityEngine;

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
    private Dictionary<string, string> atlasPool = new Dictionary<string, string>();
    private Dictionary<string, List<Action<Sprite>>> callPool = new Dictionary<string, List<Action<Sprite>>>();

    //初始化 解析图集配置
    public void initialize()
    {

    }
    private string getAtlasPath(string icon)
    {
        return atlasPool[icon];
    }

    //对外接口
    public void setImageByName(string name, Action<Sprite> callBack)
    {
        string key = getAtlasPath(name);
        if (AssetCacheMgr.Instance.isHas(key))
        {
            AssetBundle ab = AssetCacheMgr.Instance.get(key);
            if (callBack != null)
                callBack.Invoke(ab.LoadAsset<Sprite>(name));
            return;
        }
        //需要加载图集ab     
        if (!callPool.ContainsKey(name))
        {
            callPool.Add(name, new List<Action<Sprite>>());            
        }
        callPool[name].Add(callBack);
        LoaderMgr.Instance.addTask(key, onLoadFinish);
    }

    //加载ab完成
    private void onLoadFinish(bool isSuccess, string name, AssetBundle ab)
    {
        if (isSuccess)
        {
            if (callPool.ContainsKey(name)) {
                List<Action<Sprite>> handlers = callPool[name];
                Sprite sp = ab.LoadAsset<Sprite>(name);
                for (int i = 0; i < handlers.Count; i++)
                {
                    handlers[i].Invoke(sp);
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

