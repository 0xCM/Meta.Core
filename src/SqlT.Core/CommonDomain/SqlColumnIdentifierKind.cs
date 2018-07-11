//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.ComponentModel;
    
    public enum SqlColumnIdentifierKind : byte
    {
        None = 0,
        ColumnPosition,
        ColumnName,
        NameAndPosition
    }
}
