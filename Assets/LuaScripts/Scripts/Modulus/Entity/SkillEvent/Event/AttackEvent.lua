AttackEvent = SimpleClass(SkillEvent)

function AttackEvent:initialize()
	
end 

--子类重写
function AttackEvent:doEvent()
	print("<color=red>AttackEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
end 