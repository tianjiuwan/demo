using System;
using System.Collections.Generic;
using UnityEngine;

public class FsmAgent
{
    private Dictionary<E_FsmState, BaseState> statePool = null;
    private BaseState nowState = null;
    private BaseState nextState = null;
    public FsmAgent() {
        statePool = new Dictionary<E_FsmState, BaseState>();
    }

    public void addState(BaseState state) {
        this.statePool.Add(state.sType, state);
    }

    public E_FsmState transFsm(E_FsmState flag,params object[] args) {
        if (statePool.ContainsKey(flag)) {
            nextState = statePool[flag];
            nextState.onEnter(args);
            return flag;
        }
        return nowState.sType;
    }

    public void onUpdate() {
        if (nextState != null) {
            nowState = nextState;
            nextState = null;
        }
        if (nowState == null) return;
        nowState.onUpdate();
    }
}

