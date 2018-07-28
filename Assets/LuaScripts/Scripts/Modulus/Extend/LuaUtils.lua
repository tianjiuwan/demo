LuaUtils = { }
local _extend = LuaExtend

--监听输入
function LuaUtils:inputAddListener(handler)
	 LuaExtend.inputAddListener(handler)
end 
--相机
function LuaUtils:setCameraPlayer(playerId)
   LuaExtend.setCameraPlayer(playerId)
end 
function LuaUtils:setCameraObj(obj)
   LuaExtend.setCameraObj(obj)
end 

--gameobject操作
function LuaUtils:setActive(obj,bool)
   LuaExtend.setActive(obj,bool)	
end 
--递归查找obj指定子节点
function LuaUtils:getNodeByRecursion(obj,name)
	return LuaExtend.getNodeByRecursion(obj,name) 
end 
--设置到指定节点下
function LuaUtils:setUINode(root,ui,node)
	LuaExtend.setUINode(root,ui,node)
end 
--ui事件监听
function LuaUtils:addEventListener(obj)
	return LuaExtend.addEventListener(obj)
end 
function LuaUtils:setActive(obj,isActive)
   LuaExtend.setActive(obj,isActive)
end 

function LuaUtils:setObjPos(obj,x,y,z)
   LuaExtend.setObjPos(obj,x,y,z)
end

function LuaUtils:setObjPosTable(obj,lst)
   LuaUtils:setObjPos(obj,lst[1],lst[2],lst[3])
end

function LuaUtils:getAngle(dir)
   return LuaExtend.getAngle(dir)
end

--加载相关操作
--加载
function LuaUtils:loadObj(path,callBack)
	LuaExtend.resGet(path,callBack)
end 
--创建obj实体
function LuaUtils:createEntity(data)
	return LuaExtend.entityMgrCreate(data)
end 
--销毁obj
function LuaUtils:destroyObj(obj)
	LuaExtend.resDestroy(obj)
end 

--dotween
function LuaUtils:doUpDownScaleAnim(obj,title,onComplete)
    return LuaExtend.doUpDownScaleAnim(obj,title,onComplete)
end 

function LuaUtils:doLocalMoveTo(obj,dur,endVal,call,delay)
    delay = delay and delay or 0 
    return LuaExtend.doLocalMoveTo(obj,dur,endVal,call,delay)
end
--销毁tween
function LuaUtils:killTweener(tw,isDoComplete)
    LuaExtend.killTweener(tw,isDoComplete)
end 
--旋转
function LuaUtils:lerpRotation(obj,dir)
    LuaExtend.lerpRotation(obj,dir)
end 
--dofloat
function LuaUtils:doFloatTo(call,startVal,endVal,dur,finish)
   return LuaExtend.doFloatTo(call,startVal,endVal,dur,finish)
end 
