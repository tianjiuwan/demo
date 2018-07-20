using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 水平位移
/// dir 0.5f 0.1f/1帧
/// dir.normalize 1f /10 
/// </summary>
public class HorizontalMoveState : BaseState
{
    private Vector3 dir = Vector3.zero;
    private float dis = 0;
    private int endFrame = 0;
    private int tickFrame = 1;
    private int scale = 2;

    public HorizontalMoveState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }

    public override void onEnter(params object[] args)
    {
        this.dir = (Vector3)args[0];
        this.dis = (float)args[1];
        this.dir = this.dir.normalized * 0.1f/ scale;
        this.endFrame = UnityEngine.Mathf.FloorToInt(this.dis * 10* scale);
    }

    public override void onUpdate()
    {        
        if (tickFrame > endFrame)
        {
            this.onExit();
            return;
        }
        this.agent.transform.position += this.dir;
        tickFrame++;
    }
    public override void onExit()
    {
        tickFrame = 1;
        this.agent.transFsm(E_FsmState.Stand, null);
        this.agent.transAnim("idle");
    }
}
