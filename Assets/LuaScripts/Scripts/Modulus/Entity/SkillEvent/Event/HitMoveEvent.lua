HitMoveEvent = SimpleClass(SkillEvent)

function HitMoveEvent:initialize()
	self.moveCfg = ConfigHelper:getConfigByKey('MoveConfig',self.cfgId)
	self.dir = Vector3.zero
end 

--子类重写
function HitMoveEvent:doEvent()
	--print("<color=red>HitMoveEvent: </color>",self.tickFrame,SkillEventTypeLang[self.type])
	if not self.moveCfg then 
		return 
	end 
	local flag = self.moveCfg.moveType
	local role = EntityMgr:getRole(self:getRoleId())
	if role then 
		self:setDirByHit()
		if flag == FsmFlag.HorizontalMove then 
		   role:transFsm(flag,self.moveCfg.moveFrame,self.dir,self.moveCfg.param2)
		elseif flag == FsmFlag.CurveMove then 
		   role:transFsm(flag,self.moveCfg.moveFrame,self.dir,self.moveCfg.param2,self.moveCfg.param3)
		elseif flag == FsmFlag.PassivityFly then 
		   role:transFsm(flag,self.moveCfg.param3)
	    end
	end 
end 

--被击
function HitMoveEvent:setDirByHit()
	local casterId = self.args[1]
	self.dir = EntityUtils:getDirBy2R(casterId,self:getRoleId())
end 

--移动方向
function HitMoveEvent:setDirByOffset()
   self.dir = EntityUtils:getDirByOffset(self:getRoleId(),self.moveCfg.param2)
end 