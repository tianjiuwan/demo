BottomSkillUI = SimpleClass(BaseUI)

require "Assets.LuaScripts.Scripts.Modulus.RootUI.UI.Item.SkillUIItem"
--声明成员变量
local norPre = "normalSkill"
local norCount = 4
local supPre = "supSkill"
local supCount = 2
function BottomSkillUI:__init_Self()
    self.baseSkill = UIWidget.LUIWidget
    for i = 1,norCount do 
    	self[norPre..i] = UIWidget.LUIWidget
    end
    for i = 1,supCount do 
    	self[supPre..i] = UIWidget.LUIWidget
    end 

    self.base = nil 
    self.norLst = {}
    self.supLst = {}
end 

function BottomSkillUI:initLayout()   
	self.base = SkillUIItem(self.baseSkill:getObj())
    for i = 1,norCount do 
        table.insert(self.norLst,SkillUIItem(self[norPre..i]:getObj()))
    end 
     for i = 1,supCount do 
        table.insert(self.supLst,SkillUIItem(self[supPre..i]:getObj()))
    end   
end 

function BottomSkillUI:onDispose()
	if self.base then 
		self.base:onBaseDispose()
	end 
    for i = 1,self.norLst do 
        self.norLst[i]:onBaseDispose()
    end 
     for i = 1,supLst do 
        self.supLst[i]:onBaseDispose()
    end  
end 

function BottomSkillUI:onOpen()

end 

function BottomSkillUI:onRefresh()	
	if not self.vo then 
		return 
	end 
	local data = self.vo:getBaseSkill()	
	self.base:onRefresh(data)
	local norLstData = self.vo:getNorSkill()
	local supLstData = self.vo:getSupSkill()
	if norLstData then 
		for i = 1,#norLstData do 
			if i <= norCount then
			   self.norLst[i]:onRefresh(norLstData[i])
		    end
		end 
    end 
    if supLstData then 
		for i = 1,#supLstData do 
			if i <= supCount then
			   self.supLst[i]:onRefresh(supLstData[i])
		    end
		end 
    end 
end 