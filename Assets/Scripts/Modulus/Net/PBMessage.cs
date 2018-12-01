using LuaInterface;
using System;
using System.Collections.Generic;

public class PBMessage
{
    public long playerId;
    [LuaByteBufferAttribute]
    public byte[] data;
    public int cmd;
    public int len;
}

