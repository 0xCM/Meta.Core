////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum TableOptionKind : int
    {
        LockEscalation = 0,
        FileStreamOn = 1,
        DataCompression = 2,
        FileTableDirectory = 3,
        FileTableCollateFileName = 4,
        FileTablePrimaryKeyConstraintName = 5,
        FileTableStreamIdUniqueConstraintName = 6,
        FileTableFullPathUniqueConstraintName = 7,
        MemoryOptimized = 8,
        Durability = 9,
        RemoteDataArchive = 10
    }
}