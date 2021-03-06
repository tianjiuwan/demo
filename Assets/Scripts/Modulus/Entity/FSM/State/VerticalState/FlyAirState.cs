﻿using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 浮空状态 所有浮空状态应该继承此状态
/// 主动浮空
///         落地不再弹起
/// 被动浮空
///         落地根据重力加速度判断是否弹起
/// </summary>
public class FlyAirState : BaseState
{
    public FlyAirState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }

    //重力
    private float gravity = 1.5f;
    //加速度 向上向下衰减
    private float acceleratedSpeed = 0.1f;
    //加速度总量
    protected float currAccSpeed = 0f;
    //当前向上速度
    protected float upSpeed = 0f;
    //向上衰减
    protected float dampingSpeed = 0.1f;
    //坠落时候的高度
    protected float fallHeight = 0;

    //jumpstate
    private E_JumpState jumpState = E_JumpState.None;
    protected E_JumpState JumpState
    {
        set
        {
            if (jumpState == value) return;
            jumpState = value;
            //计算一个坠落时候的高度
            RaycastHit info;
            if (Physics.Raycast(this.agent.Trans.position, Vector3.down, out info, 100))
            {
                fallHeight = info.distance;
            }
            onJumpStateChange(jumpState);
        }
    }

    public virtual void onJumpStateChange(E_JumpState state)
    {

    }


    //1 speed浮空力度
    public override void onEnter(params object[] args)
    {
        float sp = float.Parse(args[0].ToString());
        this.upSpeed += sp;
    }

    public override void onUpdate()
    {
        //向上
        if (this.upSpeed > 0)
        {
            this.JumpState = E_JumpState.Up;
            this.agent.ccMove(Vector3.up * Time.deltaTime * this.upSpeed);
            this.upSpeed -= this.dampingSpeed;
            currAccSpeed = 0;
        }
        else
        {
            //重力
            this.JumpState = E_JumpState.Down;
            currAccSpeed += acceleratedSpeed;
            CollisionFlags flag = this.agent.ccMove(Vector3.down * Time.deltaTime * (gravity + currAccSpeed));
            if ((this.agent.CC.collisionFlags & CollisionFlags.Below) != 0)
                this.onExit();
        }
    }

    public override void onExit()
    {
        jumpState = E_JumpState.None;
        currAccSpeed = 0f;
        this.upSpeed = 0f;
        this.fallHeight = 0;
        this.agent.transFsm(E_FsmState.Stand, null);
        this.agent.transAnim("idle", 0.4f);
    }
}

