////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum RestoreStatementKind : int
    {
        None = 0,
        Database = 1,
        TransactionLog = 2,
        FileListOnly = 3,
        VerifyOnly = 4,
        LabelOnly = 5,
        RewindOnly = 6,
        HeaderOnly = 7
    }
}