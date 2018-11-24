EntityControl = SimpleClass(BaseControl)

function EntityControl:__init(...)

end 

function EntityControl:__init_self()
    self.mainPlayer = 10000000
    self.entityId = 10000000
    self.startZ = 10
    self.keyDownListener = Bind(self.anyKeyDown,self)
    self.keyUpListener = Bind(self.anyKeyUp,self)
end 

function EntityControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
    LuaUtils:inputAddListener(self.keyDownListener)
    LuaUtils:inputAddUpListener(self.keyUpListener)
end 

function EntityControl:anyKeyUp(code)
    --移动
    local role = EntityMgr:getMainRole()
    if role and role:canMove() then 
        if code == UnityEngine.KeyCode.UpArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_End_Drag)
        end 
        if code == UnityEngine.KeyCode.DownArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_End_Drag)
        end 
        if code == UnityEngine.KeyCode.LeftArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_End_Drag)
        end 
        if code == UnityEngine.KeyCode.RightArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_End_Drag)
        end 
    end
end 

function EntityControl:anyKeyDown(code)
    if code == UnityEngine.KeyCode.I then 
        self:createEntity()
    end 
    --其他输入
    --移动
    local role = EntityMgr:getMainRole()
    if role and role:canMove() then 
        if code == UnityEngine.KeyCode.UpArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_Drag,Vector2.up)
        end 
        if code == UnityEngine.KeyCode.DownArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_Drag,Vector2.up * -1)
        end 
        if code == UnityEngine.KeyCode.LeftArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_Drag,Vector2.right * -1)
        end 
        if code == UnityEngine.KeyCode.RightArrow then 
            EventMgr:sendMsg(JoyStickCmd.On_Drag,Vector2.right)
        end 
    end
    --技能
    if code == UnityEngine.KeyCode.Q then 
        SkillMgr:doSkill(self.mainPlayer,100001)
    end 
    if code == UnityEngine.KeyCode.W then 
        SkillMgr:doSkill(self.mainPlayer,100002)
    end 
    if code == UnityEngine.KeyCode.R then 
        SkillMgr:doSkill(self.mainPlayer,100003)
    end  
    --打开UI
    if code == UnityEngine.KeyCode.O then 
        EventMgr:sendMsg(BottomMidCmd.On_Open_UI) 
        EventMgr:sendMsg(JoyStickCmd.On_Open_UI) 
        EventMgr:sendMsg(BottomSkillCmd.On_Open_UI)         
    end        
end 

function EntityControl:createEntity()
    EntityMgr:createEntity(self.entityId)
    self.entityId = self.entityId + 1
    self.startZ = self.startZ + 2 
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')