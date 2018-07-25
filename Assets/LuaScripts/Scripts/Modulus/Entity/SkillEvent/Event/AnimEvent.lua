AnimEvent = SimpleClass(SkillEvent)

function AnimEvent:initialize()
	self.animCfg = ConfigHelper:getConfigByKey('AnimConfig',self.cfgId)
	self.animName = self.animCfg and self.animCfg.animName or nil 
end 

--子类重写
function AnimEvent:doEvent()
	print("<color=red>AnimEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		local fadeTime = self.animCfg and self.animCfg.fadeTime or 0 
		print(self.animName,fadeTime)
		role:transAnim(self.animName,fadeTime)
	end 
end 