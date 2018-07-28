JoyStickControl = SimpleClass(BaseControl)

local maxSpeed = 100--最大速度 
local subSpeed = 10--做一个衰减
local realMax = maxSpeed/subSpeed
function JoyStickControl:__init(...)

end 

function JoyStickControl:__init_self()

end 

function JoyStickControl:initEvent()
	  EventMgr:addListener(JoyStickCmd.On_Drag,Bind(self.onBeginDrag,self))
	  EventMgr:addListener(JoyStickCmd.On_Drag,Bind(self.onDrag,self))
	  EventMgr:addListener(JoyStickCmd.On_End_Drag,Bind(self.onEndDrag,self))
end 

function JoyStickControl:onDrag(dir)
   if self:checkMainPlayer() then 
   	  --change speed --真实速度 = 最大速度/速度衰减
   	  --local speed = dir.magnitude > maxSpeed and maxSpeed/subSpeed or dir.magnitude/subSpeed
   	  --change rotate 
   	  --dir = dir.normalized  
   	  --与Vector3(0,1,0)夹角   	  
   	  --local angle = LuaExtend:getVectorAngle(dir,Vector2(0,1))
   	  --angle = dir.x>0 and angle or 360 - angle   	  
   	  self.mainPlayer:updateFsm(dir)             
   end 
end 

function JoyStickControl:onEndDrag()
   if self:checkMainPlayer() then 
      self.mainPlayer:transFsm(FsmFlag.Stand)
   end 	
end 

function JoyStickControl:onBeginDrag()
   if self:checkMainPlayer() then 
   	  self.mainPlayer:transFsm(FsmFlag.Run)
   end 	
end 

function JoyStickControl:checkMainPlayer()
   if self.mainPlayer then 
      return true 
   end 
	 self.mainPlayer = EntityMgr:getMainRole()
   return self.mainPlayer 
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('JoyStickControl',UIEnum.JoyStickUI,JoyStickCmd.On_Open_UI,JoyStickCmd.On_Close_UI)