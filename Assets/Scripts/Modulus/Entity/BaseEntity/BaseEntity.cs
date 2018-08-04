using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    //状态机
    private FsmAgent fsm;
    [SerializeField]
    private E_FsmState fsmState = E_FsmState.Stand;
    public E_FsmState FsmState
    {
        get
        {
            return this.fsmState;
        }
    }
    //缓存animator
    private Animator anim;
    //缓存cc
    private CharacterController cc;
    public CharacterController CC
    {
        get
        {
            if (this.cc == null)
            {
                this.cc = this.GetComponent<CharacterController>();
            }
            return this.cc;
        }
    }
    //缓存transform
    private Transform trans;
    public Transform Trans
    {
        get
        {
            if (this.trans == null)
            {
                this.trans = this.transform;
            }
            return this.trans;
        }
    }
    //加载状态
    private E_EntityLoadState loadState = E_EntityLoadState.Waiting;
    public E_EntityLoadState LoadState
    {
        get
        {
            return this.loadState;
        }
    }
    //资源
    private GameObject prefab = null;
    public GameObject Prefab
    {
        get
        {
            return this.prefab;
        }
    }
    //实体数据
    private EntityData roleData;
    public int UID
    {
        get
        {
            return this.roleData.playerId;
        }
    }
    /*
   * cast skill 1001
   * 走20帧
   * 1帧
   * ｛
   *     锁定 int 等级xx
   *     动作 string (动画名称)
   * 音效 audioId->cfg(音效id找配置 播放音效)
   *     特效 effectId->cfg(特效id找配置 播放特效)
   *     位移 moveId->cfg(位移id找配置 位移参数 垂直or水平or曲线 位移参数...方向 距离)
   * ｝
   * 10帧｛
   *     伤害 attackId->cfg(攻击id找配置 检测范围扇形or矩形or距离 检测参数...打击效果hitId(这次打击效果 浮空or击退 锁定等级xx) )
   * ｝
   * 
   * 配置在lua那边解析 C# tick lua skillPool
   * 
   */


    /// <summary>
    ///实体锁定等级(用于实体移动 释放技能等验证)
    ///0可以移动 释放技能 (技能配置一个锁定等级字段 指定了则需求指定锁定等级 不指定则可以释放)
    ///大于0无法移动 释放技能 一般都需要0等级 如果技能指定锁定等级 则判断锁定等级释放技能
    ///玩家受击 锁定等级定位到10000起 这个时候无法移动 绝大部分技能无法释放 但是可能有反击技能（受到某种攻击可以释放的技能）
    /// </summary>
    private int lockLevel = 0;
    public int LockLevel
    {
        get
        {
            return this.lockLevel;
        }
        set
        {
            this.lockLevel = value;
        }
    }

    private void Start()
    {
        initialize();
    }

    private void Update()
    {
        if (this.fsm != null)
            fsm.onUpdate();
    }

    #region 实体提供接口
    /// <summary>
    /// 切换FSM状态
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="args"></param>
    public void transFsm(E_FsmState flag, params object[] args)
    {
        if (this.fsm != null)
            fsmState = this.fsm.transFsm(flag, args);
    }
    public void updateFsm(params object[] args)
    {
        if (this.fsm != null)
            this.fsm.updateFsm(args);
    }
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animName"></param>
    public void transAnim(string animName, float fadeTime = 0f)
    {
        if (this.anim != null)
            this.anim.CrossFade(animName, fadeTime);
    }
    /// <summary>
    /// CC移动
    /// </summary>
    /// <param name="motion"></param>
    public CollisionFlags ccMove(Vector3 motion)
    {
        if (this.CC != null)
        {
            return this.cc.Move(motion);
        }
        return CollisionFlags.None;
    }
    /// <summary>
    /// 加载模型资源
    /// @"AssetBundle\Prefabs\model\role_superman\model\role_superman"
    /// </summary>
    public void loadModel()
    {
        if (this.Prefab == null)
        {
            this.loadState = E_EntityLoadState.Loading;
            ResMgr.Instance.get(roleData.resName, loadFinish);
        }
    }
    private void loadFinish(GameObject go)
    {
        go.transform.SetParent(this.Trans);
        go.transform.localPosition = Vector3.zero;
        this.prefab = go;
        this.loadState = E_EntityLoadState.Finish;
        initialize();
    }

    public void onDispose()
    {
        if (this.LoadState == E_EntityLoadState.Loading)
        {
            ResMgr.Instance.unLoad(roleData.resName, loadFinish);
        }
        if (this.Prefab != null)
        {
            ResMgr.Instance.recyle(this.Prefab);
        }
    }
    /// <summary>
    /// 实体数据
    /// </summary>
    /// <param name="data"></param>
    public void setData(EntityData data)
    {
        this.roleData = data;
    }
    #endregion

    private void initialize()
    {
        if (cc == null)
        {
            cc = this.GetComponent<CharacterController>();
            if (cc == null)
            {
                cc = this.gameObject.AddComponent<CharacterController>();
            }
        }
        if (cc != null && this.roleData != null)
        {
            cc.height = roleData.height;
            cc.center = new Vector3(0, roleData.heightOffset, 0);
            cc.radius = roleData.radius;
            cc.skinWidth = 0.01f;
        }
        anim = this.GetComponentInChildren<Animator>();
        if (this.fsm == null)
        {
            fsm = new FsmAgent();
            fsm.addState(new StandState(this, E_FsmState.Stand));
            fsm.addState(new RunState(this, E_FsmState.Run));
            fsm.addState(new FlyAirState(this, E_FsmState.FlyAir));
            fsm.addState(new FixedFlyState(this, E_FsmState.FixedFly));
            fsm.addState(new PassivityFlyState(this, E_FsmState.PassivityFly));
            fsm.addState(new HorizontalMoveState(this, E_FsmState.HorizontalMove));
            fsm.addState(new InitiativeFlyState(this, E_FsmState.InitiativeFly));
            fsm.addState(new CurveMoveState(this, E_FsmState.CurveMove));
            fsm.addState(new StiffState(this, E_FsmState.Stiff));
            fsm.addState(new SuperArmorState(this, E_FsmState.SuperArmor));
        }
    }


}

