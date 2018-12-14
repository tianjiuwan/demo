ConfigHelper = { }

function ConfigHelper:getConfig(name)
	if _G[name] == nil then 
		require ("Client.Scripts.Config."..name)
	end 
	return _G[name]
end 

function ConfigHelper:getConfigByKey(name,key)
	if _G[name] == nil then 
		require ("Client.Scripts.Config."..name)
	end 
	return _G[name][key]
end 