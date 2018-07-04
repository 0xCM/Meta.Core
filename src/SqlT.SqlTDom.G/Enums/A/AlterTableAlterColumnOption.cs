////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AlterTableAlterColumnOption : int
    {
        NoOptionDefined = 0,
        AddRowGuidCol = 1,
        DropRowGuidCol = 2,
        Null = 3,
        NotNull = 4,
        AddPersisted = 5,
        DropPersisted = 6,
        AddNotForReplication = 7,
        DropNotForReplication = 8,
        AddSparse = 9,
        DropSparse = 10,
        AddMaskingFunction = 11,
        DropMaskingFunction = 12,
        AddHidden = 13,
        DropHidden = 14
    }
}