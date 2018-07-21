using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CS导入到Lua接口
/// </summary>
public static class LuaExtend
{
    #region ResMgr导出
    public static void resGet(string path, Action<GameObject> callBack, E_LoadType loadType = E_LoadType.None)
    {
        ResMgr.Instance.get(path, callBack, loadType);
    }
    public static void resRecyle(GameObject obj)
    {
        ResMgr.Instance.recyle(obj);
    }
    public static void resUnLoad(string path, Action<GameObject> callBack)
    {
        ResMgr.Instance.unLoad(path, callBack);
    }
    public static void resDestroy(GameObject obj)
    {
        ResMgr.Instance.destroy(obj);
    }
    #endregion
    #region EntityMgr导出
    public static void entityMgrCreate(EntityData data)
    {
        EntityMgr.Instance.createEntity(data);
    }
    #endregion
    #region logger
    public static void log(string str) {
        Debug.Log(str);
    }
    #endregion

}

