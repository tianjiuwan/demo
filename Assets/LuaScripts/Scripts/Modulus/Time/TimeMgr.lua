TimeMgr = { }

--C# Call Lua 
--1帧1次
local function tick(frameIndex)
   SkillMgr:tick(frameIndex)
end 

--C#协议过来
local function onNetMsg(pbMessage)
    local cmd = pbMessage.cmd
    local playerId = pbMessage.playerId
    local buffer = pbMessage.data

	local msg = Protol.PlayerSnapShootMsg_pb.PlayerSnapShootMsg()
	msg:ParseFromString(buffer)
	print('lua反序列化协议完成 usename '..msg.username)
end 

--赋值成员
TimeMgr.tick = tick
TimeMgr.onNetMsg = onNetMsg

create(TimeMgr)