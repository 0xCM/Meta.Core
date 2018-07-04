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
    using SqlT.Syntax;
    using SqlT.Models;    

    using sx = Syntax;
    using sxc = contracts;

    public abstract class SqlDataType<T> : SqlType<T>, sxc.ISqlDataType
        where T : SqlDataType<T>
    {
        public static implicit operator SqlTypeName(SqlDataType<T> x) => x.Name;

        internal SqlDataType(
                SqlDataTypeName TypeName,
                DataTypeCategory PrimitiveClassifier,
                sxc.native_type BaseType = null,
                bool IsNative = true,
                SqlElementDescription Documentation = null,
                bool IsNullable = true,
                bool CanSpecifyLength = false,
                bool CanSpecifyPrecision = false,
                bool CanSpecifyScale = false

            ) : base(
                TypeName.AsTypeName(), 
                Documentation: null, 
                IsNative: IsNative,
                CanSpecifyNullability: IsNullable,
                CanSpecifyLength: CanSpecifyLength,
                CanSpecifyPrecision: CanSpecifyPrecision,
                CanSpecifyScale: CanSpecifyScale
                )

        {

            this.PrimitiveClassifier = PrimitiveClassifier;
            this.BaseType = ModelOption.decide(BaseType);
        }


        public ModelOption<sxc.native_type> BaseType { get; }

        public DataTypeCategory PrimitiveClassifier { get; }

        public override string ToString()
            => LocalName;

        public override bool IsTextType
            => BaseType.map(x => x.IsTextType, () => false);

        public override bool IsAnsiTextType
            => BaseType.map(x => x.IsAnsiTextType, () => false);

        public override bool IsUnicodeTextType
            => BaseType.map(x => x.IsUnicodeTextType, () => false);
    }

}
