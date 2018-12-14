using System;
using UnityEngine;

/// <summary>
/// 池子类型
/// </summary>
public enum E_PoolType
{
    None,
    UICache,//缓存UI
    UISingle,//单例UI
    Model,//模型
    Effect,//特效
    Atlas,//图集
}

/// <summary>
/// 池子模式 
/// </summary>
public enum E_PoolMode
{
    None,
    Time,//时间池
    Level,//关卡池
    Overall,//全局池
}


public enum E_LoadStatus
{
    Wait,
    Loading,
    Finish,
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
    private static string ePre = "Assets/Res/AssetBundleExport/";

    public static string abPre
    {
        get
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                return Application.streamingAssetsPath;
            }
            else {
                return ePre;
            }
        }
    }

    public const int checkAssetBundleCacheSec = 10;
    public const int checkBasePoolSec = 60;

    //定义meunItem index
    public int buildAsssetBundle = 1001;
    public int clearAssetBundle = 1002;
    public int clearAssetBundleName = 5001;
    public int exportAtlasCfg = 6001;
}

