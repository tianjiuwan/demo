SkillMgr = { }

function SkillMgr:init()
	self.nowFrame = 0 
	self.mainPool = { }
	self.normalPool = { }
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
end 

function SkillMgr:removeMainSkill(key)
    self.mainPool[key] = nil 
end 

create(SkillMgr)