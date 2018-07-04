namespace SqlT.Syntax
{
    using System;

    using static metacore;
    using sxc = contracts;

    using SqlT.Core;

    /// <summary>
    /// Supertype for native type references
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class native_typeref<T> : typeref<T>
        where T : sxc.ISqlType, sxc.native_type
    {
        protected native_typeref(T ReferencedType, bool IsNullable = true, int? MaxLength = null,
            byte? NumericPrecision = null, byte? NumericScale = null)
                : base(ReferencedType, IsNullable, MaxLength, NumericPrecision, NumericScale)
        {

        }

        internal native_typeref(T ReferencedType, SqlDataFacets Facets)
            : base(ReferencedType, Facets)
        {

        }

        protected native_typeref(T ReferencedType, bool IsNullable, int? MaxLength) 
            : base(ReferencedType.Name, IsNullable, MaxLength, null, null)
        {

        }

        protected native_typeref(T ReferencedType, bool IsNullable, byte? Scale) 
            : base(ReferencedType.Name, IsNullable, null, null, Scale)
        {

        }
    }


}