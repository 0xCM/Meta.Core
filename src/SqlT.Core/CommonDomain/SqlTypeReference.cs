//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines a canonical information model for a type reference
    /// </summary>
    public sealed class SqlTypeReference 
    {

        public SqlTypeReference(sxc.type_ref typeref)
            : this
            (
                TypeName: typeref.type_name, 
                IsNullable: typeref.nullable, 
                Length: (typeref as sxc.data_type_ref)?.length, 
                Precision: (typeref as sxc.data_type_ref)?.precision, 
                Scale: (typeref as sxc.data_type_ref)?.scale
           )
        {

        }

        public SqlTypeReference
            (
                SqlTypeName TypeName,
                bool IsNullable = true,
                int? Length = null,
                byte? Precision = null,
                byte? Scale = null
            )
        {
            this.TypeName = TypeName;
            this.IsNullable = IsNullable;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;

        }

        public SqlTypeName TypeName { get;}

        public bool IsNullable { get; }

        public int? Length { get; }

        public byte? Precision { get; }

        public byte? Scale { get; }

        public SqlTypeReference Transform(Func<SqlTypeReference, SqlTypeReference> f)
            => f(this);
    }

}