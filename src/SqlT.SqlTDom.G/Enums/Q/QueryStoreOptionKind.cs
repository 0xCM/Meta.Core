////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum QueryStoreOptionKind : int
    {
        Desired_State = 0,
        Query_Capture_Mode = 1,
        Size_Based_Cleanup_Mode = 2,
        Flush_Interval_Seconds = 3,
        Interval_Length_Minutes = 4,
        Current_Storage_Size_MB = 5,
        Max_Plans_Per_Query = 6,
        Stale_Query_Threshold_Days = 7
    }
}