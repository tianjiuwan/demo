using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPool
{
    /*战斗逻辑帧
 * 客户端逻辑帧=1000/60 ms
 * 线程计算客户端当前帧index 
 * 释放技能 获取当前帧index 从当前帧往下走 处理配置表中的帧事件
 * 例如：玩家释放技能skill001 起始帧 520帧
 * cfg: 1帧播放攻击音效 2帧播放A特效 7帧播放B特效 4帧计算伤害  (位移todo)
 *        521                        522                    527                  524
 * 
 * BaseSkillPool
 * 缓存技能池 netSkillPool(不应该计算伤害,只播放音效特效,伤害包由服务器同步)
 * 缓存技能池 mainSkillPool(播放音效特效，计算伤害列表并发给服务器验算)
 * 客户端走每一帧 tick池子
 * 
 * 模型动画 animator or animation 
 * 
 * 
 */
    public class SkillCfg
    {
        public Animation anim;
        void addAnim(string name) {
            
        }
        public Animator animr;

    }
    public enum E_EventType
    {
        None,
        Audio,
        Effect,
        Damage,
        Move,
    }
    public class SkillEvent
    {
        public int frame;//事件播放帧
        public E_EventType type;//事件类型
        public int id;//配置id (audio->audiocfg,effect->effectcfg...)
    }
    //技能对象
    public class BaseSkill
    {
        int startFrame = 0;
        SkillCfg cfg = null;
        private Dictionary<int, List<SkillEvent>> eventPool = new Dictionary<int, List<SkillEvent>>();
        //构造
        public BaseSkill(int startIndex, SkillCfg cfg)
        {
            this.startFrame = startIndex;
            this.cfg = cfg;
            //解析一下cfg addEvent
        }
        //tick
        public void tick(int index)
        {
            if (eventPool.ContainsKey(index))
            {
                List<SkillEvent> lst = eventPool[index];
                for (int i = 0; i < lst.Count; i++)
                {
                    //todo 
                    //执行当前帧事件
                }
            }
        }
    }

}
