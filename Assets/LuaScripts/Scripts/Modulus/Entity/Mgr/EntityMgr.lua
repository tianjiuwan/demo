EntityMgr = { }

function EntityMgr:init()
	self.entityPool = { }
    self.mainRole = nil 
end 

function EntityMgr:addRole(role)
	local id = role:getId()
	self.entityPool[id] = role 
	if self.mainRole == nil then 
		self.mainRole = role 
	end 
end 

function EntityMgr:getRole(id)
	if not id then 
		return nil 
	end 
	return self.entityPool[id]
end 

function EntityMgr:getMainRole()
	return self.mainRole
end 

create(EntityMgr)