AudioEvent = SimpleClass(SkillEvent)

function AudioEvent:initialize()
	
end 

--子类重写
function AudioEvent:doEvent()
	print("<color=red>AudioEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
end 