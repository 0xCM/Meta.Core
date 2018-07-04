////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum IsolationLevel : int
    {
        None = 0,
        ReadCommitted = 1,
        ReadUncommitted = 2,
        RepeatableRead = 3,
        Serializable = 4,
        Snapshot = 5
    }
}