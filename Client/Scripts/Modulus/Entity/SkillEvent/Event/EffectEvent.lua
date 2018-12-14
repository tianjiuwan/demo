EffectEvent = SimpleClass(SkillEvent)

function EffectEvent:initialize()
	
end 

--子类重写
function EffectEvent:doEvent()
	--print("<color=red>EffectEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
end 