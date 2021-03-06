AttackEvent = SimpleClass(SkillEvent)

function AttackEvent:initialize()
	self.attackCfg = ConfigHelper:getConfigByKey('AttackConfig',self.cfgId)
end 

--子类重写
function AttackEvent:doEvent()
	  --print("<color=red>AttackEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
    if not self.attackCfg then 
    	return 
    end 
    local searchType = self.attackCfg.searchType
    --定义查找类型枚举 todo
    if searchType == 1 then 
       local dis = self.attackCfg.searchDis
       local lst = EntityUtils:searchByDistance(self:getRoleId(),dis)
       SkillMgr:hitRole(self:getRoleId(),self.attackCfg.hitId,lst)
    elseif searchType == 2 then 
       local angle = self.attackCfg.searchAngle
       local dis = self.attackCfg.searchDis
       local lst = EntityUtils:searchBySector(self:getRoleId(),angle,dis)
       SkillMgr:hitRole(self:getRoleId(),self.attackCfg.hitId,lst)  
    end 
end 