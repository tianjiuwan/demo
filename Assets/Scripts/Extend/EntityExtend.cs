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

    //更新fsm状态机数据
    public static void updateFsm(int roleId, params object[] args)
    {
        BaseEntity role = EntityMgr.Instance.getEntity(roleId);
        if (role != null)
        {
            role.updateFsm(args);
        }
    }
    //移动
    public static void move(int roleId, Vector3 motion)
    {
        BaseEntity role = EntityMgr.Instance.getEntity(roleId);
        if (role != null)
        {
            role.ccMove(motion);
        }
    }
    #region 搜索相关
    //距离搜索
    public static List<int> searchByDistance(int searchId, float distance)
    {
        return SearchUtils.getByDistance(searchId, distance);
    }
    //扇形搜索
    public static List<int> searchBySector(int searchId, float angle, float distance)
    {
        return SearchUtils.getBySector(searchId, angle, distance);
    }
    #endregion
    //获取实体向前偏移的向量
    public static Vector3 getDirByOffset(int roleId, float offset)
    {
        BaseEntity role = EntityMgr.Instance.getEntity(roleId);
        if (role == null) return Vector3.zero;
        if (offset == 0) return role.Trans.forward;
        Quaternion rot = Quaternion.Euler(0, offset, 0) * role.Trans.rotation;
        return rot * Vector3.forward;
    }
    //获取两个实体间的向量
    public static Vector3 getDirBy2R(int casterId, int hitRoleId)
    {
        BaseEntity caster = EntityMgr.Instance.getEntity(casterId);
        BaseEntity hitRole = EntityMgr.Instance.getEntity(hitRoleId);
        if (hitRole == null || caster == null) return Vector3.zero;
        return  hitRole.Trans.position- caster.Trans.position;
    }
}

