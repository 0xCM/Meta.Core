//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using Meta.Models;

    using SqlT.Core;    

    using sxc = contracts;

    /// <summary>
    /// Represents a sql data type
    /// </summary>
    public abstract class data_type<T> : sql_type<T,SqlDataTypeName>, sxc.ISqlDataType
        where T : data_type<T>
    {
        protected data_type(SqlDataTypeName TypeName, DataTypeCategory PrimitiveClassifier,
                sxc.native_type BaseType = null, bool IsNative = true, bool IsNullable = true,
                bool CanSpecifyLength = false, bool CanSpecifyPrecision = false,
                bool CanSpecifyScale = false) 
                    : base(TypeName, 
                        IsNative: IsNative,
                        CanSpecifyNullability: IsNullable,
                        CanSpecifyLength: CanSpecifyLength,
                        CanSpecifyPrecision: CanSpecifyPrecision,
                        CanSpecifyScale: CanSpecifyScale)
        {
            this.PrimitiveClassifier = PrimitiveClassifier;
            this.BaseType = ModelOption.decide(BaseType);
        }


        public ModelOption<sxc.native_type> BaseType { get; }

        public DataTypeCategory PrimitiveClassifier { get; }

        public override string ToString()
            => Name.UnquotedLocalName;

        public override bool IsTextType
            => BaseType.map(x => x.IsTextType, () => false);

        public override bool IsAnsiTextType
            => BaseType.map(x => x.IsAnsiTextType, () => false);

        public override bool IsUnicodeTextType
            => BaseType.map(x => x.IsUnicodeTextType, () => false);
    }



}
