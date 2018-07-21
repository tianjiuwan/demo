using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主动浮空
/// </summary>
public class InitiativeFlyState : FlyAirState
{
    public InitiativeFlyState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {

       
    }

    public override void onJumpStateChange(E_JumpState state)
    {
        if (state == E_JumpState.Up)
        {
            this.agent.transAnim("jumpUp");
        }
        else if(state == E_JumpState.Down) {
            this.agent.transAnim("jumpDown");
        }
    }


}

