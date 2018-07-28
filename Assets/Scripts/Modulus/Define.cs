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

/// <summary>
/// 
/// </summary>
public enum E_SkillEventType
{
    None,
    Audio,
    Effect,
    Damage,
    Move,
}

public enum E_FsmState
{
    Stand,    

    FlyAir,
    PassivityFly,
    InitiativeFly,
    FixedFly,
    CurveMove,
    HorizontalMove,

    SuperArmor,
    Stiff,
    Run,
}

public enum E_JumpState
{
    None,
    Up,
    Down,
}

/// <summary>
/// 实体类型
/// </summary>
public enum E_EntityType
{
    None,
    Player,
    Monster,
    Npc,
}

/// <summary>
/// 实体加载状态
/// </summary>
public enum E_EntityLoadState
{
    Waiting,
    Loading,
    Finish,
    Invaild,
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


    public const int checkAssetBundleCacheSec = 10;
    public const int checkBasePoolSec = 60;

    //定义meunItem index
    public int buildAsssetBundle = 1001;
    public int clearAssetBundle = 1002;
    public int clearAssetBundleName = 5001;
    public int exportAtlasCfg = 6001;


}