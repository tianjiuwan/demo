LRole = SimpleClass()

function LRole:__init_self()
   self.id = nil 
   self.lockUID = 0 
   self.lockLevel = 0
   self.nowCastSkills = { }
   self.nowHits = { }
end 

function LRole:__init(id)
	self:__init_self()
    self.id = id 
end 

function LRole:getId()
	return self.id 
end 

function LRole:getFlag()
  return EntityUtils:getFlag(self.id)
end 

--flag==stand or run 
--lock <=0
function LRole:canMove()
   local lock = self:getLockLevel()
   if lock>0 then 
      return false
   end 
   local flag = self:getFlag()
   return flag == FsmFlag.Stand or flag == FsmFlag.Run 
end 

function LRole:setLockLevel(uid,lv)   
   if self.lockUID == uid or self.lockUID == 0 or lv > self.lockLevel then 
   	  self.lockUID = uid
   	  self.lockLevel = lv 
      --print('LRole set lock uid ',uid,lv)
   end 
end 

--skill
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

--hit
function LRole:addHit(uid)
   self.nowHits[uid] = true 
end 
function LRole:removeHit(uid)
  self.nowHits[uid] = nil 
end 
function LRole:getHits()
  return self.nowHits
end 

--受击
function LRole:onHit()

end 

--死亡
function LRole:onDie()

end 

function LRole:transAnim(name,time)
    EntityUtils:transAnim(self.id,name,time)
end 

function LRole:transFsm(flag,...)
    EntityUtils:transFsm(self.id,flag,...)
end 
function LRole:updateFsm(...)
    EntityUtils:updateFsm(self.id,...)
end

function LRole:move(dir)
    EntityUtils:move(self.id,dir)
end 