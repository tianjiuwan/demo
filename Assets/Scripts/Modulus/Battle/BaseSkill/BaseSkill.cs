using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill
{
    public int skillUID = 0;//uid
    int skillId = 0;//skillId
    int startFrame = 0;//其实帧
    int maxFrame = 0;//最大帧
    SkillCfg cfg = null;//技能配置
    //key = frameIndex val = skillevent
    private Dictionary<int, List<BaseSkillEvent>> eventPool = new Dictionary<int, List<BaseSkillEvent>>();
    //构造
    public BaseSkill(int uid, int startIndex, SkillCfg cfg)
    {
        this.skillUID = uid;
        this.startFrame = startIndex;
        this.cfg = cfg;
        //解析一下cfg addEvent
        //是netPlayer不需要解析伤害事件
        BaseSkillEvent skillEvent1 = new BaseSkillEvent(this.startFrame + 1, E_SkillEventType.Audio);
        BaseSkillEvent skillEvent2 = new BaseSkillEvent(this.startFrame + 2, E_SkillEventType.Effect);
        BaseSkillEvent skillEvent3 = new BaseSkillEvent(this.startFrame + 6, E_SkillEventType.Damage);
        BaseSkillEvent skillEvent4 = new BaseSkillEvent(this.startFrame + 6, E_SkillEventType.Damage);
        BaseSkillEvent skillEvent5 = new BaseSkillEvent(this.startFrame + 300, E_SkillEventType.Damage);
        eventPool.Add(this.startFrame + 1, new List<BaseSkillEvent>() { skillEvent1 });
        eventPool.Add(this.startFrame + 2, new List<BaseSkillEvent>() { skillEvent2 });
        eventPool.Add(this.startFrame + 6, new List<BaseSkillEvent>() { skillEvent3, skillEvent4 });
        eventPool.Add(this.startFrame + 300, new List<BaseSkillEvent>() { skillEvent5 });
        maxFrame = this.startFrame + 300;
    }
    //tick
    public void tick(int index)
    {
        if (eventPool.ContainsKey(index))
        {
            List<BaseSkillEvent> lst = eventPool[index];
            for (int i = 0; i < lst.Count; i++)
            {
                //执行当前帧事件
                if (lst[i].frameIndex == index)
                {
                    Debug.Log("do skill event eType <color=red>" + lst[i].eType.ToString() + " </color> frameIndex " + lst[i].frameIndex);
                }
            }
        }

    }

    public bool canRemove(int index)
    {
        return index >= maxFrame;
    }

}
