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
        self:mainPlayerCastSkill()
    end 
end 

function EntityControl:createEntity()
    local data = EntityData()
    data.playerId = self.entityId
    data.height = 2
    data.heightOffset = 1
    data.radius = 0.3
    data.resName = "AssetBundle/Prefabs/model/role_ueman/model/role_ueman"
    data.initPosition = Vector3(10, 0, self.startZ);
    local role =LuaExtend.entityMgrCreate(data)
    local lrole = LRole(self.entityId,role)
    EntityMgr:addRole(lrole)
    self.entityId = self.entityId + 1
    self.startZ = self.startZ + 2 
end 

function EntityControl:mainPlayerCastSkill()
   local mainRole = EntityMgr:getMainRole()
   if mainRole then 
      local skillId = 100002
      local skillCfg = ConfigHelper:getConfigByKey('SkillConfig',skillId)
      if skillCfg then 
          local lockLevel = skillCfg.lockLevel
          if mainRole:getLockLevel() >= lockLevel then 
             print('无法释放技能 锁定等级不够')
             return 
          end 
          local map = { }
          local nowFrame = SkillMgr:getFrame()
          local roleId = mainRole:getId()
          local uid = LuaExtend.getUID()
          for i = 1,10 do 
              local frame = skillCfg['event'..i]
              if frame ~= nil then                  
                 local realFrame = nowFrame+frame
                 if map[realFrame] == nil then 
                    map[realFrame] = { }
                 end 
                 local data = SkillEventFactory:create(uid,roleId,realFrame,skillCfg['eventType'..i],skillCfg['eventId'..i])--SkillFrameData(realFrame,skillCfg['eventType'..i],cfg)                 
                 table.insert(map[realFrame],data)
              end 
          end 
          local maxFrame = skillCfg.maxFrame+nowFrame
          local skillData = SkillData(uid,roleId,map,skillCfg,maxFrame)
          SkillMgr:addMainSkill(skillData)
          --mainRole:transAnim(skillCfg.animName,0)
      end       
   end 
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')