LockEvent = SimpleClass(SkillEvent)

function LockEvent:initialize()
	self.lockLevel = self.cfgId
end 

--子类重写
function LockEvent:doEvent()
	--print("<color=red>LockEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		role:setLockLevel(self:getUID(),self.lockLevel)
	end 
end 