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