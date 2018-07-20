using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A 
/// </summary>
public class BaseState
{
    public BaseEntity agent;
    public E_FsmState sType;
    public BaseState(BaseEntity agent, E_FsmState sType)
    {
        this.agent = agent;
        this.sType = sType;
    }

    public virtual void onEnter(params object[] args)
    {

    }

    public virtual void onUpdate()
    {

    }

    public virtual void onExit()
    {

    }
}

