EntityControl = SimpleClass(BaseControl)

function EntityControl:__init(...)

end 

function EntityControl:__init_self()

end 

function EntityControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')