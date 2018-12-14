EffectMgr = { }

local effectPath = "AssetBundle/Prefabs/effect/"
function EffectMgr:init()
    
end 

function EffectMgr:createInRole(eid,roleId,offset)
   local cfg = ConfigHelper:getConfigByKey('EffectConfig',eid)
   if cfg then 
   	  local str = {}
   	  table.insert(str,effectPath)
   	  table.insert(str,cfg.path)
   	  local path = table.concat(str)
   	  --local lifeTime = cfg.time 
      LuaUtils:loadObj(path,function(obj) 
         LuaUtils:setParent2Role(obj,roleId,offset)
         LuaUtils:playEffect(obj)
         LuaUtils:addSecHandler(2,nil,function() 
         	LuaUtils:recyleObj(obj)
         end)
      end)
   end 
end 

create(EffectMgr)