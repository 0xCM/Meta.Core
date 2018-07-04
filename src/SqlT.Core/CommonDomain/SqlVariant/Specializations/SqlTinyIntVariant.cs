//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using VT = SqlTinyIntVariant;
    using DT = System.String;

    /// <summary>
    /// Represents a variant value that has an underlying type of tinyint
    /// </summary>
    public readonly struct SqlTinyIntVariant : ISqlVariant<VT, DT>
    {
        public static implicit operator VT(DT x)
            => new VT(x);

        public static implicit operator DT(VT x)
            => x.Value;

        public DT Value { get; }

        public SqlTinyIntVariant(DT Value)
            => this.Value = Value;

        object ISqlVariant.Value
            => Value;
        public override string ToString()
            => Value.ToString();

        SqlVariantKind ISqlVariant.VariantKind
            => SqlVariantKind.Tinyint;

    }
}