LRole = SimpleClass()

function LRole:__init_self()
   self.id = nil 
   self.role = nil 
end 

function LRole:__init(id)
	self:__init_self()
    self.id = id 
end 

function LRole:getId()
	return self.id 
end 

function LRole:transAnim(name,time)
    EntityExtend.transAnim(self.id,name,time)
end 