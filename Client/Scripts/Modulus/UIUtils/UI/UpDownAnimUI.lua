UpDownAnimUI = SimpleClass(BaseUI)

function UpDownAnimUI:__init_Self()
	self.animObj = UIWidget.LUIWidget
end 

function UpDownAnimUI:initLayout()
    LuaUtils:setActive(self.animObj:getObj(),false)
end 

function UpDownAnimUI:onOpen()
	if self.animObj ~= nil then 
		LuaUtils:setActive(self.animObj:getObj(),true)
		local str = self.args and tostring(self.args) or "喵喵喵？喵喵喵？喵喵喵？喵喵喵？"
		LuaUtils:doUpDownScaleAnim(self.animObj:getObj(),str,function() UIMgr:closeUI(UIEnum.UpDownAnimUI) end)
	end 
end 

function UpDownAnimUI:onClose()

end 

function UpDownAnimUI:onDispose()

end 