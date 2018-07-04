////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum StatisticsOptionKind : int
    {
        FullScan = 0,
        SamplePercent = 1,
        SampleRows = 2,
        StatsStream = 3,
        NoRecompute = 4,
        Resample = 5,
        RowCount = 6,
        PageCount = 7,
        All = 8,
        Columns = 9,
        Index = 10,
        Rows = 11,
        Incremental = 12
    }
}