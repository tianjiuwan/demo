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

    /// <summary>
    /// 方向 距离 时间
    /// 计算出每帧速度
    /// 
    /// </summary>
    /// <param name="args"></param>
    public override void onEnter(params object[] args)
    {

        this.endFrame = int.Parse(args[0].ToString());
        float offset = float.Parse(args[1].ToString());
        this.dis = float.Parse(args[2].ToString());

        Quaternion rot = Quaternion.Euler(0, offset, 0) * this.agent.Trans.rotation;
        // Vector3 pos = rot * new Vector3(0, 0, this.dis) + this.agent.Trans.position;
        this.dir = rot * Vector3.forward; //pos-this.agent.Trans.position;
        float sc = dis / this.endFrame;
        this.dir = this.dir.normalized * sc;
    }

    public override void onUpdate()
    {
        if (tickFrame > endFrame)
        {
            this.onExit();
            return;
        }
        //this.agent.transform.position += this.dir;
        this.agent.ccMove(this.dir);
        tickFrame++;
    }
    public override void onExit()
    {
        tickFrame = 1;
        this.agent.transFsm(E_FsmState.Stand, null);
        this.agent.transAnim("idle", 0.2f);
    }
}
