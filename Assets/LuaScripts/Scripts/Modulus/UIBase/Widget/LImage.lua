LImage = SimpleClass(LUIWidget)
--[[
image动态设置sprite
做一个动态引用
UI回对象池释放动态引用
--]]
function LImage:getWidget()
    return self.widgetObj:GetComponent("Image") 
end 

function LImage:initialize()
	self.dyName = nil 
    self.dyDep = nil 
    self.loadSpriteFinish = Bind(self.onSpriteLoadFinish,self)
end 

--Image一些相关操作--todo
function LImage:setImage(name)
	print("<color=blue>onSpriteLoadFinish name </color>"..name)
	--先unload
	if self.dyName then 
       LuaUtils:unloadSprite(self.dyName,self.loadSpriteFinish)
       self.dyName = nil 
    end 
    LuaUtils:setSprite(name,self.loadSpriteFinish)
    self.dyName = name
end 

function LImage:onSpriteLoadFinish(sprite,resName)
	print("<color=red>onSpriteLoadFinish resName </color>"..resName)
    if self.dyDep then 
    	LuaUtils:subRef(self.dyDep)
    end    
    self.widget.sprite = sprite
    self.dyDep = resName
    LuaUtils:addRef(self.dyDep)
end 

function LImage:setNativeSize()
	if self.widget then 
		self.widget:SetNativeSize()
	end 
end 

function LImage:setFillAmount(val)
	if self.widget then 
		self.widget.fillAmount = val
	end 
end 

function LImage:setMaterialFloat(key,val)
	LuaUtils:setMaterialFloat(self.widget,key,val)
end 

function LImage:onDispose()
	--移除回调
	if self.dyName then 
       LuaUtils:unloadSprite(self.dyName,self.loadSpriteFinish)
       self.dyName = nil 
    end 
    self.loadSpriteFinish = nil 
    --移除动态引用
    if self.dyDep then 
    	LuaUtils:subRef(self.dyDep)
    end 
end 