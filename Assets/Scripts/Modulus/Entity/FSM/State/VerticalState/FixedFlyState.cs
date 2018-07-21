using System;
using System.Collections.Generic;
using UnityEngine;

public class FixedFlyState : BaseState
{
    public FixedFlyState(BaseEntity entity, E_FsmState sType) : base(entity, sType)
    {

    }
    private Vector3 fixedPoint = Vector3.zero;
    private int fixedFrame = 0;
    private int nowFrame = 0;

    public override void onEnter(params object[] args)
    {
        this.fixedPoint = (Vector3)args[0];
        this.fixedFrame = (int)args[1];
        this.agent.Trans.position = this.fixedPoint;
    }

    public override void onUpdate()
    {
        if (this.nowFrame >= this.fixedFrame)
        {
            this.onExit();
            return;
        }
        this.nowFrame++;
    }

    public override void onExit()
    {
        nowFrame = 0;
        fixedFrame = 0;
        fixedPoint = Vector3.zero;
        this.agent.transFsm(E_FsmState.PassivityFly, new object[] { 0});
        this.agent.transAnim("lieDown");
    }
}

