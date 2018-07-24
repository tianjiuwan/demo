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

    private BaseEntity mainPlayer = null;
    public BaseEntity MainPlayer
    {
        get
        {
            return this.mainPlayer;
        }
    }

    public Dictionary<int, BaseEntity> epool = new Dictionary<int, BaseEntity>();
    private Dictionary<E_EntityType, List<BaseEntity>> tpool = new Dictionary<E_EntityType, List<BaseEntity>>();

    public BaseEntity createEntity(EntityData data)
    {
        if (epool.ContainsKey(data.playerId))
        {
            return epool[data.playerId];
        }
        GameObject go = new GameObject(data.playerId.ToString());
        go.transform.position = data.initPosition;
        BaseEntity role = go.AddComponent<BaseEntity>();
        role.setData(data);
        role.loadModel();
        epool.Add(data.playerId, role);
        if (MainPlayer == null)
        {
            mainPlayer = role;
        }
        return role;
    }

    public void recyleEntity(BaseEntity role)
    {

    }

    public BaseEntity getEntity(int id)
    {
        if (epool.ContainsKey(id))
        {
            return epool[id];
        }
        return null;
    }
    public T getEntity<T>(int id) where T : BaseEntity
    {
        return epool[id] as T;
    }


}

