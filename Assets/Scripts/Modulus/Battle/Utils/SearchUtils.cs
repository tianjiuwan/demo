using System;
using System.Collections.Generic;
using UnityEngine;

public class SearchUtils
{
    //距离检测
    public static List<int> getByDistance(int caster, float distance)
    {
        BaseEntity casterRole = EntityMgr.Instance.getEntity(caster);
        if (casterRole == null)
            return null;
        List<int> lst = new List<int>();
        foreach (var item in EntityMgr.Instance.epool)
        {
            if (item.Value.UID == casterRole.UID) continue;
            if (Vector3.Distance(item.Value.Trans.position, casterRole.Trans.position) <= distance)
                lst.Add(item.Key);
        }
        return lst;
    }
    //矩形检测
    //扇形检测
    public static List<int> getBySector(int caster, float angle, float distance)
    {
        BaseEntity casterRole = EntityMgr.Instance.getEntity(caster);
        if (casterRole == null)
            return null;
        #if  UNITY_EDITOR
                drawSector(casterRole, angle, distance);
        #endif
        List<int> lst = new List<int>();
        foreach (var item in EntityMgr.Instance.epool)
        {
            if (item.Value.UID == casterRole.UID) continue;
            if (Vector3.Distance(item.Value.Trans.position, casterRole.Trans.position) > distance) continue;
            //计算夹角
            Vector3 vec = item.Value.Trans.position - casterRole.Trans.position;
            if (Vector3.Angle(casterRole.Trans.forward, vec)<=angle) {
                lst.Add(item.Key);
            }
        }
        return lst;
    }
    public static void drawSector(BaseEntity role,float angle,float dis) {
        Quaternion left = Quaternion.Euler(0, angle / 2, 0) * role.Trans.rotation;
        Vector3 leftPos = role.Trans.position + left * Vector3.forward * dis;
        Quaternion right = Quaternion.Euler(0, -angle / 2, 0) * role.Trans.rotation;
        Vector3 rightPos = role.Trans.position + right * Vector3.forward * dis;
        Debug.DrawLine(role.Trans.position, leftPos,Color.red,2f);
        Debug.DrawLine(role.Trans.position, rightPos, Color.red,2f);
        Debug.DrawLine(leftPos, rightPos, Color.red,2f);
    }

}

