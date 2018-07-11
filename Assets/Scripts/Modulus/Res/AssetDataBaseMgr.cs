using UnityEngine;
using UnityEditor;

public class AssetDataBaseMgr
{
    /// <summary>
    /// 封装一层AssetDataBase.load
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T load<T>(string path) where T : UnityEngine.Object
    {
        return null;// AssetDatabase.LoadAssetAtPath<T>(path);
    }

    /// <summary>
    /// loadAll
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static UnityEngine.Object[] loadAll(string path)
    {
        return null;// AssetDatabase.LoadAllAssetsAtPath(path);
    }
}

