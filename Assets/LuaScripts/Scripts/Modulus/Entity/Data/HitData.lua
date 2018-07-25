HitData = SimpleClass()

function HitData:__init_self()
	self.uid = nil 
	self.roleId = nil 
	self.eventMap = nil 
	self.hitCfg = nil 
	self.maxFrame = nil 
end 

function HitData:__init(uid,roleId,map,cfg,maxFrame)
	self.uid = uid 
	self.roleId = roleId 
	self.eventMap = map 
	self.hitCfg = cfg
	self.maxFrame = maxFrame
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