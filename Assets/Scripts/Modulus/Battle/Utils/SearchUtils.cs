using System;
using System.Collections.Generic;
using UnityEngine;

public class SearchUtils
{
    //距离检测
    public static List<BaseEntity> getByDistance(BaseEntity caster, float distance)
    {
        List<BaseEntity> lst = new List<BaseEntity>();
        foreach (var item in EntityMgr.Instance.epool)
        {
            if (item.Value.UID == caster.UID) continue;
            if (Vector3.Distance(item.Value.Trans.position, caster.Trans.position) <= distance)
                lst.Add(item.Value);
        }
        return lst;
    }
    //矩形检测
    //扇形检测


}

