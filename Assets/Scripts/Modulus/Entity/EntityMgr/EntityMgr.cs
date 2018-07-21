using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr
{
    private static EntityMgr instance;
    public static EntityMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EntityMgr();
            }
            return instance;
        }
    }

    private Dictionary<int, BaseEntity> epool = new Dictionary<int, BaseEntity>();
    private Dictionary<E_EntityType, List<BaseEntity>> tpool = new Dictionary<E_EntityType, List<BaseEntity>>();

    public void createEntity(EntityData data)
    {
        if (epool.ContainsKey(data.playerId))
        {
            return;
        }
        GameObject go = new GameObject(data.playerId.ToString());
        go.transform.position = data.initPosition;
        BaseEntity role = go.AddComponent<BaseEntity>();
        role.setData(data);
        role.loadModel();
        epool.Add(data.playerId, role);
    }

    public void recyleEntity(BaseEntity role)
    {

    }
}

