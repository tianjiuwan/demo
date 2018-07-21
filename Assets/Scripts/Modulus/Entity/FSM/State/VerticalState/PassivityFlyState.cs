using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 被动浮空
/// </summary>
public class PassivityFlyState : FlyAirState
{
    public PassivityFlyState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }
    //多大加速度会被弹起
    private float spring = 2f;

    public override void onUpdate()
    {
        base.onUpdate();
    }

    public override void onExit()
    {
        //Debug.LogError(this.fallHeight);
        if (this.fallHeight >= spring)
        {
            this.upSpeed = spring + this.fallHeight * 0.1f;
            this.fallHeight = 0;
        }
        else
        {
            currAccSpeed = 0f;
            this.upSpeed = 0f;
            this.agent.transFsm(E_FsmState.Stand, null);
            this.agent.transAnim("idle", 0.2f);
        }
    }


}

