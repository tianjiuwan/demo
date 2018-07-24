TimeMgr = { }

--C# Call Lua 
--1帧1次
local function tick(frameIndex)
   SkillMgr:tick(frameIndex)
end 

TimeMgr.tick = tick

create(TimeMgr)