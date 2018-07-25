LRole = SimpleClass()

function LRole:__init_self()
   self.id = nil 
   self.lockUID = 0 
   self.lockLevel = 0
   self.nowCastSkills = { }
end 

function LRole:__init(id)
	self:__init_self()
    self.id = id 
end 

function LRole:getId()
	return self.id 
end 

function LRole:setLockLevel(uid,lv)   
   if self.lockUID == uid or self.lockUID == 0 or lv > self.lockLevel then 
   	  self.lockUID = uid
   	  self.lockLevel = lv 
   end 
end 

function LRole:getLockLevel()
	return self.lockLevel
end 

function LRole:addCastSkill(uid)
   self.nowCastSkills[uid] = true 
end 
function LRole:removeCastSkill(uid)
	self.nowCastSkills[uid] = nil 
end 

function LRole:getCastSkill()
	return self.nowCastSkills
end 

--受击
function LRole:onHit()

end 

--死亡
function LRole:onDie()

end 

function LRole:transAnim(name,time)
    EntityExtend.transAnim(self.id,name,time)
end 

function LRole:transFsm(flag,...)
    EntityExtend.transFsm(self.id,flag,...)
end 