SkillEventFactory = { }

local eventMap = { }
eventMap[SkillEventType.Lock] = LockEvent
eventMap[SkillEventType.Anim] = AnimEvent
eventMap[SkillEventType.Audio] = AudioEvent
eventMap[SkillEventType.Effect] = EffectEvent
eventMap[SkillEventType.Move] = MoveEvent
eventMap[SkillEventType.Attack] = AttackEvent
eventMap[SkillEventType.HitMove] = HitMoveEvent

local function getClass(etype)
    local class = eventMap[etype]
    if class == nil then
        class = SkillEvent
    end
    return class
end

function SkillEventFactory:create(uid,roleId,frame,type,cfg,...)   
   local class = getClass(type)
   return class(uid,roleId,frame,type,cfg,...)
end
 
create(SkillEventFactory)