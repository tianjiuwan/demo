SkillData = SimpleClass()

function SkillData:__init_self()
	self.uid = nil 
	self.roleId = nil 
	self.eventMap = nil 
	self.skilCfg = nil 
	self.maxFrame = nil 
end 

function SkillData:__init(uid,roleId,map,cfg,maxFrame)
	self.uid = uid 
	self.roleId = roleId 
	self.eventMap = map 
	self.skilCfg = cfg 
	self.maxFrame = maxFrame
	self.lockLevel = self.skilCfg and self.skilCfg.lockLevel or 0 
end 

function SkillData:hasEvents(frame)
	return self.eventMap[frame] ~= nil 
end 

function SkillData:getEvents(frame)
	return self.eventMap[frame] 
end 

function SkillData:canRemove(frame)
	return frame >= self.maxFrame
end 

function SkillData:getUID()
	return self.uid
end 

function SkillData:getRoleId()
	return self.roleId
end 

function SkillData:onStart()
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		role:setLockLevel(self:getUID(),self.lockLevel)
	end 
end 
function SkillData:onFinish()
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		role:setLockLevel(self:getUID(),0)
	end 
end 