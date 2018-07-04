//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using VT = SqlDecimalVariant;
    using DT = System.Decimal;

    /// <summary>
    /// Represents a variant value that has an underlying type of decimal
    /// </summary>
    public readonly struct SqlDecimalVariant : ISqlVariant<VT, DT>
    {
        public static implicit operator VT(DT x)
            => new VT(x);

        public static implicit operator DT(VT x)
            => x.Value;

        public DT Value { get; }

        public SqlDecimalVariant(DT Value)
            => this.Value = Value;

        object ISqlVariant.Value
            => Value;
        public override string ToString()
            => Value.ToString();

        SqlVariantKind ISqlVariant.VariantKind
            => SqlVariantKind.Decimal;

    }
}