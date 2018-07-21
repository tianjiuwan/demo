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

    private void Start()
    {
        initialize();
    }

    private void Update()
    {
        if (this.fsm != null)
            fsm.onUpdate();
        //水平位移 前进
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward, 1f });
            this.transAnim("attack");
        }
        //水平位移 被击退
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward * -1, 1f });
            this.transAnim("hart");
        }
        //被击飞 曲线移动        
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.transFsm(E_FsmState.CurveMove, new object[] { new Vector3(0, 0, 0), 6f, 6f });
            this.transAnim("lieDown");
        }
        //浮空 主动
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.transFsm(E_FsmState.InitiativeFly, new object[] { 6f });
        }
        //被击 浮空
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.transFsm(E_FsmState.PassivityFly, new object[] { 5f });
            this.transAnim("lieDown");
        }
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
            ResMgr.Instance.get(roleData.resName, (go) =>
            {
                go.transform.SetParent(this.Trans);
                go.transform.localPosition = Vector3.zero;
                this.prefab = go;
                initialize();
            });
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
        }
        anim = this.GetComponentInChildren<Animator>();
        if (this.fsm == null)
        {
            fsm = new FsmAgent();
            fsm.addState(new StandState(this, E_FsmState.Stand));
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

