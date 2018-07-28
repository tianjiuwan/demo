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

function EntityMgr:createEntity(playerId)
    local data = EntityData()
    data.playerId = playerId
    data.height = 2
    data.heightOffset = 1
    data.radius = 0.3
    data.resName = "AssetBundle/Prefabs/model/role_ueman/model/role_ueman"
    data.initPosition = Vector3(0, 0, 0);
    local role = LuaUtils:createEntity(data)
    local lrole = LRole(playerId,role)
    EntityMgr:addRole(lrole)
end 

create(EntityMgr)