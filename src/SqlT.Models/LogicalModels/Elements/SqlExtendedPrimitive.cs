//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;

    using SqlT.Core;
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;

    [SqlElementType(SqlElementTypeNames.ExtendedPrimitive)]
    public sealed class SqlExtendedPrimitive : SqlDataType<SqlExtendedPrimitive>
    {
        public SqlExtendedPrimitive
        (
            SqlDataTypeName TypeName,
            sxc.native_type BaseType = null,
            SqlElementDescription Documentation = null
        )
        : base
            (
                TypeName: TypeName, 
                PrimitiveClassifier:  DataTypeCategory.None,
                BaseType : BaseType, 
                Documentation : Documentation, 
                IsNative: false
            )
        { }


    }

}
