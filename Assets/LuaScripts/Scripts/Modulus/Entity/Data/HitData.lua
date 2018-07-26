HitData = SimpleClass()

function HitData:__init_self()
	self.uid = nil 
	self.roleId = nil 
	self.eventMap = nil 
	self.hitCfg = nil 
	self.maxFrame = nil 
	self.casterId = nil 
end 

function HitData:__init(uid,roleId,map,cfg,maxFrame,casterId)
	self.uid = uid 
	self.roleId = roleId 
	self.eventMap = map 
	self.hitCfg = cfg
	self.maxFrame = maxFrame
	self.casterId = casterId 
	self.lockLevel = self.hitCfg and self.hitCfg.lockLevel or 0 
end 

function HitData:hasEvents(frame)
	return self.eventMap[frame] ~= nil 
end 

function HitData:getEvents(frame)
	return self.eventMap[frame] 
end 

function HitData:canRemove(frame)
	return frame >= self.maxFrame
end 

function HitData:getUID()
	return self.uid
end 

function HitData:getRoleId()
	return self.roleId
end 

function HitData:onStart()
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		role:setLockLevel(self:getUID(),self.lockLevel)
	end 
end 

function HitData:onFinish()
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		role:setLockLevel(self:getUID(),0)
	end 
end 