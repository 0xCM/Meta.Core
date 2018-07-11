//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;


    /// <summary>
    /// Classifies a variant value
    /// </summary>
    public enum SqlVariantKind
    {
        Unspecified,
        DateTime2,
        DateTimeOffset,
        DateTime,
        SmallDateTime,
        Date,
        Time,
        Float,
        Real,
        Decimal,
        Money,
        SmallMoney,
        Bigint,
        Int,
        Smallint,
        Tinyint,
        Bit,
        NVarChar,
        NChar,
        VarChar,
        Char,
        Varbinary,
        Binary,
        UniqueIdentifier
    }


}