////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum IndexOptionKind : int
    {
        PadIndex = 0,
        FillFactor = 1,
        SortInTempDB = 2,
        IgnoreDupKey = 3,
        StatisticsNoRecompute = 4,
        DropExisting = 5,
        Online = 6,
        AllowRowLocks = 7,
        AllowPageLocks = 8,
        MaxDop = 9,
        LobCompaction = 10,
        FileStreamOn = 11,
        DataCompression = 12,
        MoveTo = 13,
        BucketCount = 14,
        StatisticsIncremental = 15,
        Order = 16,
        CompressAllRowGroups = 17,
        CompressionDelay = 18
    }
}