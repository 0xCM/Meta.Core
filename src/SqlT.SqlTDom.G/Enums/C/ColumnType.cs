////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum ColumnType : int
    {
        Regular = 0,
        IdentityCol = 1,
        RowGuidCol = 2,
        Wildcard = 3,
        PseudoColumnIdentity = 4,
        PseudoColumnRowGuid = 5,
        PseudoColumnAction = 6,
        PseudoColumnCuid = 7
    }
}