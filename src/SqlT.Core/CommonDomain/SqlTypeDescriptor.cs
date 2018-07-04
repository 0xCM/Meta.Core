//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines a canonical information model for a type reference
    /// </summary>
    public sealed class SqlTypeDescriptor 
    {

        public SqlTypeDescriptor(sxc.type_ref typeref)
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

        public SqlTypeDescriptor
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

        public SqlTypeDescriptor Transform(Func<SqlTypeDescriptor, SqlTypeDescriptor> f)
            => f(this);
    }

}