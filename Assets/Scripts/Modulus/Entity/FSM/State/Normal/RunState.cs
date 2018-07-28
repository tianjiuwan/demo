using System;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }

    private Vector3 motion = Vector3.zero;
    Quaternion rot = Quaternion.identity;
    private float speed = 1;

    public override void onEnter(params object[] args)
    {
        this.agent.transAnim("run");
        this.updateArgs(args);
    }
    public override void onUpdate()
    {
        this.agent.ccMove(this.motion * 0.1f * speed);

        this.agent.Trans.rotation = Quaternion.Lerp(this.agent.Trans.rotation, rot, 0.8f);
    }

    public override void onExit()
    {
        motion = Vector3.zero;
        rot = Quaternion.identity;
        speed = 1;
    }

    public override void updateArgs(params object[] args)
    {
        if (args == null || args.Length <= 0) return;
        Vector2 joy = (Vector2)args[0];
        motion.x = joy.x;
        motion.y = 0;
        motion.z = joy.y;
        motion = motion.normalized;
        float ang = Vector3.SignedAngle(Vector3.forward, this.motion, Vector3.up);
        ang = ang > 0 ? ang : 360 + ang;
        rot = Quaternion.Euler(0, ang, 0);
    }

}

