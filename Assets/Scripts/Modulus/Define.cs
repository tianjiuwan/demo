using System;
using System.Collections.Generic;

/// <summary>
/// 加载状态
/// </summary>
public enum E_LoaderStatus
{
    Waiting,
    Loading,
    Finish,
}
/// <summary>
/// 池子类型
/// </summary>
public enum E_PoolType
{
    None,
    Time,
    Level,
    Global,
}
/// <summary>
/// 加载类型
/// ui model ...
/// </summary>
public enum E_LoadType
{
    None,
    UI,
    Model,
}

public class Define
{
    /// <summary>
    /// 编辑器下面资源的前缀
    /// </summary>
    public const string editorPre = "Assets/Res/";
    /// <summary>
    /// ab资源前缀
    /// </summary>
    public const string abPre = "Assets/Res/AssetBundleExport/";
    public const string atlasBundleName = "AssetBundle/cfgs/atlasCfg";

    //定义meunItem index
    public int buildAsssetBundle = 1001;
    public int clearAssetBundle = 1002;
    public int clearAssetBundleName = 5001;
    public int exportAtlasCfg = 6001; 


}