SkillMgr = { }

function SkillMgr:init()
	self.nowFrame = 0 
	self.mainPool = { }
	self.normalPool = { }
	self.hitPool = { }
end 

function SkillMgr:tick(index)
	--print('SkillMgr ',index)
	self.nowFrame = index
	for k,v in pairs(self.mainPool) do 
		local has = v:hasEvents(self.nowFrame)
		if has then 
			local eventsLst = v:getEvents(self.nowFrame)
			for i = 1,#eventsLst do 
				eventsLst[i]:doEvent()
			end 
		end 
		if v:canRemove(self.nowFrame) then 
		   v:onFinish()
		   self:removeMainSkill(k)
		end 
	end
	for k,v in pairs(self.hitPool) do 
		local has = v:hasEvents(self.nowFrame)
		if has then 
			local eventsLst = v:getEvents(self.nowFrame)
			for i = 1,#eventsLst do 
				eventsLst[i]:doEvent()
			end 
		end 
		if v:canRemove(self.nowFrame) then 
		   self:removeMainSkill(k)
		end 
	end 
end 

function SkillMgr:getFrame()
	return self.nowFrame
end 

function SkillMgr:addMainSkill(skill)
	if not skill then 
		return 
	end 
	local uid = skill:getUID() 
    self.mainPool[uid] = skill
    skill:onStart()
end 

function SkillMgr:removeMainSkill(key)
    self.mainPool[key] = nil 
end 

function SkillMgr:removeRoleSkill(role)
	if role then 
		local skills = role:getCastSkill()
		for k,v in pairs(skills) do 
			self.mainPool[k] = nil 
		end 
	end 
end 

function SkillMgr:doAttack(atkEvent)
    local roleId = atkEvent:getRoleId()
    local atkCfg = atkEvent:getCfg()
    if not roleId or not atkCfg then 
    	return 
    end     
    local searchType = atkCfg.searchType
    local hitRoles = { }
    
end 

create(SkillMgr)