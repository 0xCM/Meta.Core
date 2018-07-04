//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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