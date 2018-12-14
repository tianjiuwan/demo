function create(class)
   if class then 
   	  if class.init then 
         class:init()
   	  end 
   end
end 
--基础模块
require "Client.Scripts.Modulus.Net.__init"
require "Client.Scripts.Modulus.Cmd.__init"
require "Client.Scripts.Modulus.Extend.__init"
require "Client.Scripts.Modulus.ClassBase.__init"
require "Client.Scripts.Modulus.Event.__init"
require "Client.Scripts.Modulus.Register.__init"
require "Client.Scripts.Modulus.Helper.__init"
require "Client.Scripts.Modulus.UIBase.__init"
require "Client.Scripts.Modulus.UIUtils.__init"

--时间
require "Client.Scripts.Modulus.Time.__init"
--功能模块
require "Client.Scripts.Modulus.RootUI.__init"
require "Client.Scripts.Modulus.Entity.__init"
require "Client.Scripts.Modulus.Effect.__init"