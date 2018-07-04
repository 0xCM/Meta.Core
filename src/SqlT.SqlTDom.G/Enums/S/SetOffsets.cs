////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum SetOffsets : int
    {
        None = 0,
        Select = 1,
        From = 2,
        Order = 4,
        Compute = 8,
        Table = 16,
        Procedure = 32,
        Execute = 64,
        Statement = 128,
        Param = 256
    }
}