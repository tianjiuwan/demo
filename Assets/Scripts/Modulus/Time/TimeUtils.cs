using System;
using System.Collections.Generic;

public class TimeUtils
{
    static private System.DateTime startTime;

    public static double getMillTime()
    {
        TimeSpan ts = DateTime.UtcNow - startTime;
        return ts.TotalMilliseconds;     //精确到毫秒
    }

    public static double getSecTime()
    {
        TimeSpan ts = DateTime.UtcNow - startTime;
        return ts.TotalSeconds;     //精确到秒
    }
}

