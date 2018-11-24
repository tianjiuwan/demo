LUIWidget = SimpleClass()

-- 初始化自身变量
local function _create_my_self(self)

end

function LUIWidget:__init(widgetObj,...)
    -- 这里防止 子类不写__init 方法而导致重入
    if self._init ~= nil and self._init == true then
        return
    end
    _create_my_self(self)
    self.widgetObj = widgetObj
    self.widget = self:getWidget()
    self:initialize()   
    self._init = true
end

function LUIWidget:initialize()

end 

--LUIWidget不带组件
function LUIWidget:getWidget()

end 

function LUIWidget:getObj()
   return self.widgetObj
end 

function LUIWidget:setPosition(x,y,z)
   LuaUtils:setObjPos(self:getObj(),x,y,z)
end 

function LUIWidget:getPosition()
    return self.widgetObj.transform.localPosition
end 

function LUIWidget:getWorldPosition()
    return self.widgetObj.transform.position
end 

function LUIWidget:setScale(x,y,z)
    
end 

function LUIWidget:setAngle(x,y,z)
    
end 

function LUIWidget:onDispose()

end 

function LUIWidget:setActive(b)
    LuaUtils:setActive(self:getObj(),b)
end

function LUIWidget:onBaseDispose()
    --print("<color=red>LUIWidget:onBaseDispose()</color>")
    self:onDispose()
    self._init = nil 
    self.widgetObj = nil 
    self.widget = nil 
end 