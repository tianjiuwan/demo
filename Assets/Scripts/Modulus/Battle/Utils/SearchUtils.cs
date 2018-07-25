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


}

