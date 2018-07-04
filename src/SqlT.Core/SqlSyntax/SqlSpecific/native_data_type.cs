//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using SqlT.Core;

    using sxc = contracts;

    public abstract class native_data_type<t> : data_type<t>, sxc.native_type
        where t : native_data_type<t>
    {
        protected native_data_type(SqlDataTypeName TypeName, bool CanSpecifyLength,
                DataTypeCategory PrimitiveClassifier, bool CanSpecifyPrecision = false,
                bool CanSpecifyScale = false, bool IsNullable = true)
            : base(TypeName, PrimitiveClassifier,
                  CanSpecifyLength: CanSpecifyLength,
                  CanSpecifyPrecision: CanSpecifyPrecision,
                  CanSpecifyScale: CanSpecifyScale,
                  IsNullable: IsNullable,
                  IsNative: true)
        { }

        bool IEquatable<sxc.ISqlDataType>.Equals(sxc.ISqlDataType other)
            => this.Name == other.Name;
    }

    /// <summary>
    /// Represents an intrinsic SQL Server data type 
    /// </summary>
    public sealed class native_data_type : native_data_type<native_data_type>
    {
        internal native_data_type(SqlDataTypeName TypeName, bool CanSpecifyLength,
                DataTypeCategory PrimitiveClassifier, bool CanSpecifyPrecision = false,
                bool CanSpecifyScale = false, bool IsNullable = true)
            : base(TypeName, CanSpecifyLength, PrimitiveClassifier, CanSpecifyPrecision, CanSpecifyScale, CanSpecifyLength)
                  
        { }

    }

}