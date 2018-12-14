SkillUIItem = SimpleClass(BaseItem)

function SkillUIItem:__init()

end 

function SkillUIItem:__init_Self()
    self.skillIcon = UIWidget.LImage
    self.skillName = UIWidget.LText
    self.cdMask = UIWidget.LImage
    self.coolText = UIWidget.LText

    self.useCommon = true 
end 

function SkillUIItem:initLayout()
	local listener = LuaUtils:addEventListener(self.obj)
	listener:setUseAnim(true)
  listener:setClickHandler(function()  	
    	if not self.isInCd and self.data then 
	    	local id = self.data:getId()
	    	EventMgr:sendMsg(BottomSkillCmd.On_Cast_Skill,id)
 	        --print("cast skill skillID "..id)
    	end 
      --测试动态设置sprite
      --self.skillIcon:setImage(107501001)
      --107501001 commonatals
      --KFSJ_1 teamatlas
      --[[测试1：引用不同图集
      if self.useCommon then 
         self.useCommon = false 
         self.skillIcon:setImage(107501001)
      else
         self.useCommon = true  
         self.skillIcon:setImage('KFSJ_1')
      end 
      --]]

      ---[[测试2：unload
         self.skillIcon:setImage(107501001) 
         self.skillIcon:setImage('KFSJ_1')
      --]]
  end)
end

function SkillUIItem:onOpen()
	--print("zzzzzfunction SkillUIItem:onOpen()")
end 

function SkillUIItem:onRefresh(data)
   if not data then 
   	  return 
   end 
   self.data = data 
   local icon = self.data:getIcon()
   self.skillIcon:setImage(icon)
   local name = self.data:getSkillName()
   self.skillName:setText(name)
   local isInCd = self.data:isInCd()
   self.isInCd = isInCd
   if isInCd then 
   	  self.cdMask:setActive(true)
   	  self.cdMask:setFillAmount(1)
   	  local cd = self.data:getSkillCd()
   	  self.coolText:setText(cd)
   	  LuaUtils:doFloatTo(function(val) self.cdMask:setFillAmount(val) self.coolText:setText(self.data:getLeftCd()) end,1,0,cd,function() 
   	  	self.cdMask:setActive(false) self.isInCd = false self.coolText:setText('') end)
   end 
end 