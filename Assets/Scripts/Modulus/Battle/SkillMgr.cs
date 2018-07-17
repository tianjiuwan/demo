using System;
using System.Collections.Generic;

public class SkillMgr
{
    private static SkillMgr instance;
    public static SkillMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkillMgr();
            }
            return instance;
        }
    }

    //key = skillUID  
    Dictionary<int, BaseSkill> mainPool = new Dictionary<int, BaseSkill>();
    Dictionary<int, BaseSkill> netPool = new Dictionary<int, BaseSkill>();

    public void addMainSkill(BaseSkill baseSkill)
    {
        mainPool.Add(baseSkill.skillUID, baseSkill);
    }
    public void addNetSkill(BaseSkill baseSkill)
    {
        mainPool.Add(baseSkill.skillUID, baseSkill);
    }

    private List<int> mainRemoveKeys = new List<int>();
    private List<int> netRemoveKeys = new List<int>();
    public void tick(int index)
    {
        foreach (var item in mainPool)
        {
            item.Value.tick(index);
            bool canRemove = item.Value.canRemove(index);
            if (canRemove)
                mainRemoveKeys.Add(item.Key);
        }
        foreach (var item in netPool)
        {
            item.Value.tick(index);
            bool canRemove = item.Value.canRemove(index);
            if (canRemove)
                netRemoveKeys.Add(item.Key);
        }
        for (int i = 0; i < mainRemoveKeys.Count; i++)
        {
            mainPool.Remove(mainRemoveKeys[i]);
        }
        mainRemoveKeys.Clear();
        for (int i = 0; i < netRemoveKeys.Count; i++)
        {
            netPool.Remove(netRemoveKeys[i]);
        }
        netRemoveKeys.Clear();
    }
}

