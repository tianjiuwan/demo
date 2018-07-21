function create(class)
   if class then 
   	  if class.init then 
         class:init()
   	  end 
   end
end 
--基础模块
require "Assets.LuaScripts.Scripts.Modulus.ClassBase.__init"
require "Assets.LuaScripts.Scripts.Modulus.Event.__init"
require "Assets.LuaScripts.Scripts.Modulus.Register.__init"

--功能模块
require "Assets.LuaScripts.Scripts.Modulus.Entity.__init"