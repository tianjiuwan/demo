SkillEvent = SimpleClass()

function SkillEvent:__init_self()
	self.uid = nil 
	self.roleId = nil 
	self.tickFrame = nil 
	self.type = nil 
	self.cfgId = nil 
	self.cfg = nil 
end 

function SkillEvent:__init(uid,roleId,frame,type,cfgId)
	self.uid = uid 
	self.roleId = roleId 
	self.tickFrame = frame 
	self.type = type 
	self.cfgId = cfgId 
	self:initialize()
end

function SkillEvent:getRoleId()
	return self.roleId
end 
function SkillEvent:getCfg()
	return self.cfg
end 
function SkillEvent:getUID()
	return self.uid 
end 

--子类重写
function SkillEvent:initialize()

end 

--子类重写
function SkillEvent:doEvent()
	print("<color=red>SkillEvent: </color>",self.tickFrame,self.type)
end 