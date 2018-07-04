//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    using static metacore;

    using VT = SqlUniqueIdentifierVariant;
    using DT = System.Guid;

    /// <summary>
    /// Represents a variant value that has an underlying type of uniqueidentifier
    /// </summary>
    public readonly struct SqlUniqueIdentifierVariant : ISqlVariant<VT, DT>
    {
        public static implicit operator VT(DT x)
            => new VT(x);

        public static implicit operator DT(VT x)
            => x.Value;

        public DT Value { get; }

        public SqlUniqueIdentifierVariant(DT Value)
            => this.Value = Value;

        object ISqlVariant.Value
            => Value;
        public override string ToString()
            => Value.ToString();

        SqlVariantKind ISqlVariant.VariantKind
            => SqlVariantKind.UniqueIdentifier;

    }

}