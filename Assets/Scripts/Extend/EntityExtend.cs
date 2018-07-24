using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 实体接口导出
/// </summary>
public static class EntityExtend
{
    //动画接口
    public static void transAnim(int roleId, string animName, float fadeTime = 0f)
    {
        BaseEntity role = EntityMgr.Instance.getEntity(roleId);
        if (role != null)
        {
            role.transAnim(animName, fadeTime);
        }
    }
    //fsm接口
    public static void transFsm(int roleId, int flag, params object[] args)
    {
        BaseEntity role = EntityMgr.Instance.getEntity(roleId);
        if (role != null)
        {
            E_FsmState eFlag = (E_FsmState)flag;
            role.transFsm(eFlag, args);
        }
    }
    //实体fsm状态


}

