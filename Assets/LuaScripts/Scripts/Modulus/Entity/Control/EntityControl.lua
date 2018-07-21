EntityControl = SimpleClass(BaseControl)

function EntityControl:__init(...)

end 

function EntityControl:__init_self()

end 

function EntityControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
	--local GameObject = UnityEngine.GameObject
    --print(GameObject==nil)
    --local go = GameObject('gzzzzzo')

    --LuaExtend.log("zzzzzzzzzzz")
    LuaExtend.inputAddListener(function(code)  
        if code == UnityEngine.KeyCode.H then 
        	print('hhhhhhhhh')
        end 
    end)
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('EntityControl')