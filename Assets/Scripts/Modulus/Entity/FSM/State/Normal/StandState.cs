using System;
using System.Collections.Generic;

public class StandState : BaseState
{
    public StandState(BaseEntity agent, E_FsmState sType) : base(agent, sType)
    {
    }

    public override void onEnter(params object[] args)
    {
        this.agent.transAnim("idle", 0.1f);
    }

}

