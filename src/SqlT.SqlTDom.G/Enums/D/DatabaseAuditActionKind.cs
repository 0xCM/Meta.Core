////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum DatabaseAuditActionKind : int
    {
        Select = 0,
        Update = 1,
        Insert = 2,
        Delete = 3,
        Execute = 4,
        Receive = 5,
        References = 6
    }
}