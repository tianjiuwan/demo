MoveEvent = SimpleClass(SkillEvent)

function MoveEvent:initialize()
	self.moveCfg = ConfigHelper:getConfigByKey('MoveConfig',self.cfgId)
end 


--子类重写
function MoveEvent:doEvent()
	--print("<color=red>MoveEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
	if not self.moveCfg then 
		return 
	end 
	local flag = self.moveCfg.moveType
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		if flag == FsmFlag.HorizontalMove then 
		   role:transFsm(flag,self.moveCfg.moveFrame,self.moveCfg.param1,self.moveCfg.param2)
		elseif flag == FsmFlag.CurveMove then 
		   role:transFsm(flag,self.moveCfg.moveFrame,self.moveCfg.param1,self.moveCfg.param2,self.moveCfg.param3)
	    end
	end 
end 