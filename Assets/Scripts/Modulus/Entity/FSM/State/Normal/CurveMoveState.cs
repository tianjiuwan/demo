﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class CurveMoveState : BaseState
{
    public CurveMoveState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }

    private int endFrame = 0;
    private float moveTime = 0;
    private float curveSpeed = 1f;
    private Vector3 P0 = Vector3.zero;
    private Vector3 P1 = Vector3.zero;
    private Vector3 P2 = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;
    private Vector3 dyPos = Vector3.zero;

    //1targetPos 2 距离 3 高度
    public override void onEnter(params object[] args)
    {
        this.endFrame = int.Parse(args[0].ToString());
        float offset = float.Parse(args[1].ToString());
        Quaternion rot = Quaternion.Euler(0, offset, 0) * this.agent.Trans.rotation;
        Vector3 dir = rot * Vector3.forward;
        float dis = float.Parse(args[2].ToString());
        float height = float.Parse(args[3].ToString());
        curveSpeed = 1f;
        P0 = this.agent.Trans.position;
        dir = dir.normalized;
        P1 = (P0 + dir * dis / 2) + Vector3.up * height;
        P2 = P0 + dir * dis;
        //Debug.DrawLine(P0, P1, Color.red, 1f);
        //Debug.DrawLine(P1, P2, Color.red, 1f);
        //下面画贝塞尔曲线
        Vector3 drawPos = P0;
        for (int i = 0; i < 100; ++i)
        {
            float t = i * 0.01f;
            Vector3 bPos = (1 - t) * (1 - t) * P0 + 2 * t * (1 - t) * P1 + t * t * P2;
            Debug.DrawLine(drawPos, bPos, Color.red, 1f);
            drawPos = bPos;
        }
    }

    public override void onUpdate()
    {
        moveTime += Time.deltaTime * curveSpeed;
        Vector3 bPos = (1 - moveTime) * (1 - moveTime) * P0 + 2 * moveTime * (1 - moveTime) * P1 + moveTime * moveTime * P2;
        moveDir = bPos - this.agent.Trans.position;
        this.agent.ccMove(moveDir);
        if (moveTime >= 1)
        {
            onExit();
        }
    }

    public override void onExit()
    {
        moveTime = 0;
        curveSpeed = 1f;
        P0 = Vector3.zero;
        P1 = Vector3.zero;
        P2 = Vector3.zero;
        moveDir = Vector3.zero;
        dyPos = Vector3.zero;
        this.agent.transFsm(E_FsmState.Stand, null);
        this.agent.transAnim("idle", 0.4f);
    }

}

