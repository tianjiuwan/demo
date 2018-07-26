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
    LuaExtend.inputAddListener(Bind(self.anyKeyDown,self))
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
    if code == UnityEngine.KeyCode.F then 
        SkillMgr:doSkill(self.mainPlayer,100003)
    end     
end 

function EntityControl:createEntity()
    local data = EntityData()
    data.playerId = self.entityId
    data.height = 2
    data.heightOffset = 1
    data.radius = 0.3
    data.resName = "AssetBundle/Prefabs/model/role_ueman/model/role_ueman"
    data.initPosition = Vector3(0, 0, 0);
    local role =LuaExtend.entityMgrCreate(data)
    local lrole = LRole(self.entityId,role)
    EntityMgr:addRole(lrole)
    self.entityId = self.entityId + 1
    self.startZ = self.startZ + 2 
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')