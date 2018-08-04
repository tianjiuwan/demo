function create(class)
   if class then 
   	  if class.init then 
         class:init()
   	  end 
   end
end 
--基础模块
require "Assets.LuaScripts.Scripts.Modulus.Cmd.__init"
require "Assets.LuaScripts.Scripts.Modulus.Extend.__init"
require "Assets.LuaScripts.Scripts.Modulus.ClassBase.__init"
require "Assets.LuaScripts.Scripts.Modulus.Event.__init"
require "Assets.LuaScripts.Scripts.Modulus.Register.__init"
require "Assets.LuaScripts.Scripts.Modulus.Helper.__init"
require "Assets.LuaScripts.Scripts.Modulus.UIBase.__init"
require "Assets.LuaScripts.Scripts.Modulus.UIUtils.__init"

--时间
require "Assets.LuaScripts.Scripts.Modulus.Time.__init"
--功能模块
require "Assets.LuaScripts.Scripts.Modulus.RootUI.__init"
require "Assets.LuaScripts.Scripts.Modulus.Entity.__init"
require "Assets.LuaScripts.Scripts.Modulus.Effect.__init"