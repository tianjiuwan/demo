EntityControl = SimpleClass(BaseControl)

function EntityControl:__init(...)

end 

function EntityControl:__init_self()
    self.mainPlayer = 10000000
    self.entityId = 10000000
    self.startZ = 10
end 

function EntityControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
    LuaUtils:inputAddListener(Bind(self.anyKeyDown,self))
end 

function EntityControl:anyKeyDown(code)
    if code == UnityEngine.KeyCode.Q then 
        self:createEntity()
    end 
    --其他输入
    if code == UnityEngine.KeyCode.O then 
        SkillMgr:doSkill(self.mainPlayer,100001)
    end 
    if code == UnityEngine.KeyCode.P then 
        SkillMgr:doSkill(self.mainPlayer,100002)
    end 
    if code == UnityEngine.KeyCode.K then 
        SkillMgr:doSkill(self.mainPlayer,100003)
    end  
    --打开UI
    if code == UnityEngine.KeyCode.T then 
        EventMgr:sendMsg(BottomMidCmd.On_Open_UI) 
        EventMgr:sendMsg(JoyStickCmd.On_Open_UI) 
    end        
end 

function EntityControl:createEntity()
    EntityMgr:createEntity(self.entityId)
    self.entityId = self.entityId + 1
    self.startZ = self.startZ + 2 
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')