using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    private FsmAgent fsm;
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        fsm = new FsmAgent();
        fsm.addState(new StandState(this, E_FsmState.Stand));
        fsm.addState(new HorizontalMoveState(this, E_FsmState.HorizontalMove));
        fsm.addState(new VerticalMoveState(this, E_FsmState.VerticalMove));
        fsm.addState(new StiffState(this, E_FsmState.Stiff));
        fsm.addState(new SuperArmorState(this, E_FsmState.SuperArmor));
    }

    private void Update()
    {
        fsm.onUpdate();
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward, 1f });
            this.transAnim("attack");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            this.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward*-1, 1f });
            this.transAnim("hart");
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
        this.fsm.transFsm(flag, args);
    }

    public void transAnim(string animName) {
        this.anim.CrossFade(animName,0f);
    }
    #endregion
}

