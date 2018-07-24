SkillFrameData = SimpleClass()

function SkillFrameData:__init_self()
	self.tickFrame = nil 
	self.type = nil 
	self.cfg = nil 
end 

function SkillFrameData:__init(frame,type,cfg)
	self.tickFrame = frame 
	self.type = type 
	self.cfg = cfg 
end

function SkillFrameData:doEvent()
	print("<color=red>技能帧事件触发: </color>",self.tickFrame,self.type)
end 