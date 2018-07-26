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
			v:onFinish()
		    self:removeHit(k)
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

------------------hit----------------------
function SkillMgr:addHit(hitData)
	if not hitData then 
		return 
	end 
	local uid = hitData:getUID() 
    self.hitPool[uid] = hitData
    hitData:onStart()
end 

function SkillMgr:removeHit(key)
    self.hitPool[key] = nil 
end 

function SkillMgr:removeRoleHit(role)
	if role then 
		local hits = role:getHits()
		for k,v in pairs(hits) do 
			self.hitPool[k] = nil 
		end 
	end 
end 

function SkillMgr:hitRole(casterId,hitId,lst)
	if not hitId or not lst then 
		return 
	end 
	local ier = lst:GetEnumerator()
	local hitCfg = ConfigHelper:getConfigByKey('HitConfig',hitId)
	while ier:MoveNext() do 
		--print('<color=red>hit role </color>',ier.Current)
        self:doHit(casterId,hitCfg,ier.Current)
	end 
end 

--受击处理
function SkillMgr:doHit(casterId,hitCfg,roleId)
   local role = EntityMgr:getRole(roleId)
   if role then 
      if hitCfg then 
          local lockLevel = hitCfg.lockLevel
          if role:getLockLevel() >= lockLevel then 
             return 
          end 
          local map = { }
          local nowFrame = self:getFrame()
          local roleId = role:getId()
          local uid = LuaExtend.getUID()
          for i = 1,10 do 
              local frame = hitCfg['event'..i]
              if frame ~= nil then                  
                 local realFrame = nowFrame+frame
                 if map[realFrame] == nil then 
                    map[realFrame] = { }
                 end 
                 local data = SkillEventFactory:create(uid,roleId,realFrame,hitCfg['eventType'..i],hitCfg['eventId'..i])
                 table.insert(map[realFrame],data)
              end 
          end 
          local maxFrame = hitCfg.maxFrame+nowFrame
          local hitData = HitData(uid,roleId,map,hitCfg,maxFrame,casterId)
          self:addHit(hitData)
      end       
   end 
end 

--释放技能
function SkillMgr:doSkill(roleId,skillId)
   local role = EntityMgr:getRole(roleId)
   if role then 
      local skillCfg = ConfigHelper:getConfigByKey('SkillConfig',skillId)
      if skillCfg then 
          local lockLevel = skillCfg.lockLevel
          if role:getLockLevel() >= lockLevel then 
             print('无法释放技能 锁定等级不够')
             return 
          end 
          local map = { }
          local nowFrame = self:getFrame()
          local roleId = role:getId()
          local uid = LuaExtend.getUID()
          for i = 1,10 do 
              local frame = skillCfg['event'..i]
              if frame ~= nil then                  
                 local realFrame = nowFrame+frame
                 if map[realFrame] == nil then 
                    map[realFrame] = { }
                 end 
                 local data = SkillEventFactory:create(uid,roleId,realFrame,skillCfg['eventType'..i],skillCfg['eventId'..i])--SkillFrameData(realFrame,skillCfg['eventType'..i],cfg)                 
                 table.insert(map[realFrame],data)
              end 
          end 
          local maxFrame = skillCfg.maxFrame+nowFrame
          local skillData = SkillData(uid,roleId,map,skillCfg,maxFrame)
          self:addMainSkill(skillData)
      end       
   end 
end 

create(SkillMgr)