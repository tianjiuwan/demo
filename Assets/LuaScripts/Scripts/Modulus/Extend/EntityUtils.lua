EntityUtils = { }
local _extend = EntityExtend

function EntityUtils:transAnim(roleId,animName,fadeTime)
    EntityExtend.transAnim(roleId,animName,fadeTime)
end

function EntityUtils:transFsm(roleId,flag,...)
    EntityExtend.transFsm(roleId,flag,...)
end 
function EntityUtils:updateFsm(roleId,...)
    EntityExtend.updateFsm(roleId,...)
end

function EntityUtils:move(roleId,dir)
    EntityExtend.move(roleId,dir)
end 

--搜索相关
--距离搜索
function EntityUtils:searchByDistance(roleId,dis)
	return EntityExtend.searchByDistance(roleId,dis)
end 
--扇形搜索
function EntityUtils:searchBySector(roleId,angle,dis)
	return EntityExtend.searchBySector(roleId,angle,dis)
end 
--获取实体偏移方向
function EntityUtils:getDirByOffset(roleId,offset)
	return EntityExtend.getDirByOffset(roleId,offset)
end 
--获取两个实体向量
function EntityUtils:getDirBy2R(castId,hitId)
	return EntityExtend.getDirBy2R(castId,hitId)
end 