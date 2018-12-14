BottomMidUI = SimpleClass(BaseUI)

local mainId = 900000010001 
--声明成员变量
function BottomMidUI:__init_Self()
	self.mp = UIWidget.LImage
	self.hp = UIWidget.LImage
	self.createPlayerBtn = UIWidget.LButton
	self.deleteBtn = UIWidget.LButton
	self.createAIBtn = UIWidget.LButton
	self.index = 800000010001
	self.entityIndex = 10001
end 

function BottomMidUI:initLayout()  
    LuaUtils:doFloatTo(function(val) self.hp:setMaterialFloat("_Fill",val) end,1,0.65,0.5)
    LuaUtils:doFloatTo(function(val) self.mp:setMaterialFloat("_Fill",val) end,1,0.25,0.5)
end 

function BottomMidUI:onOpen()

end 