using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseSkillEvent
{
    public int frameIndex = 0;
    public int cfgId = 0;
    public E_SkillEventType eType = E_SkillEventType.None;

    public BaseSkillEvent(int index, E_SkillEventType type) {
        frameIndex = index;
        eType = type;
    }

}

