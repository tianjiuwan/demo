MoveEvent = SimpleClass(SkillEvent)

function MoveEvent:initialize()
	
end 

--子类重写
function MoveEvent:doEvent()
	print("<color=red>MoveEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
end 