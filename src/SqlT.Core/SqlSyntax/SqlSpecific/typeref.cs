//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.ComponentModel;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public abstract class typeref<m, t> : Model<m>, sxc.data_type_ref
        where m : typeref<m, t>
        where t : sxc.ISqlType
    {

        protected typeref(t ReferencedType, bool IsNullable, int? MaxLength = null, 
            byte? NumericPrecision = null, byte? NumericScale = null) 
                : this(ReferencedType.Name, IsNullable, MaxLength, NumericPrecision, NumericScale)
                    => Validate(ReferencedType, new SqlDataFacets(not(IsNullable), MaxLength, NumericPrecision, NumericScale));

        protected typeref(SqlTypeDescriptor d)
            : this(d.TypeName, d.IsNullable, d.Length, d.Precision, d.Scale)
        {

        }

        protected typeref(SqlTypeName name, bool nullable, int? maxlen = null,
                byte? precision = null, byte? scale = null )
        {
            this.type_name = name.AsDataTypeName();
            this.nullable = nullable;
            this.length = maxlen;
            this.precision = precision;
            this.scale = scale;

        }

        public typeref(t ReferencedType, SqlDataFacets Facets)
            : this(ReferencedType.Name, Facets.IsValueOptional, Facets.MaxLength,
                    Facets.NumericPrecision, Facets.NumericScale)
                        => Validate(ReferencedType, Facets);


        /// <summary>
        /// The SQL type identified by the reference
        /// </summary>
        SqlTypeName sxc.type_ref.type_name { get; }

        public SqlDataTypeName type_name { get; }

        /// <summary>
        /// Specifies whether a value must be specified when creating a value of the referenced type
        /// </summary>
        public bool nullable { get; }

        /// <summary>
        /// Specifies the maximum length of a value of the referenced type, if applicable
        /// </summary>
        public int? length { get; }

        /// <summary>
        /// Specifies the numeric precision of a value of the referended type, if applicable
        /// </summary>
        public byte? precision { get; }

        /// <summary>
        /// Specifies the numeric scale a value of the referended type, if applicable
        /// </summary>
        public byte? scale { get; }

        /// <summary>
        /// Specifies whether the referenced type is a table type
        /// </summary>
        public virtual bool is_table_type
            => false;

        /// <summary>
        /// Specifies the types' facets
        /// </summary>
        public SqlDataFacets facets
            => new SqlDataFacets(not(nullable), length, precision, scale);

        public abstract sxc.data_type_ref retype(SqlTypeDescriptor descriptor);

        public override string ToString()
        {
            var nullable = this.nullable ? " null" : " not null";

            if (scale != null && precision == null)
                return $"{type_name.UnqualifiedName}({scale}) {nullable}";

            if (precision != null && scale != null)
                return $"{type_name.UnqualifiedName}({precision}{scale}) {nullable}";

            var length = this.length != null && this.length != 0 ? $"({this.length.ToString()})" : string.Empty;
            var text = type_name.UnqualifiedName + length + nullable;
            return text;
        }

        static void Validate(t ReferencedType, SqlDataFacets facets)
        {
            var dataTypeName = ReferencedType.Name.UnqualifiedName;
            if ((ReferencedType is sxc.native_type))
            {
                if (!ReferencedType.CanSpecifyLength && facets.MaxLength != null)
                {
                    throw new ArgumentException($"Cannot specify length for {dataTypeName} data type");
                }

                if (!ReferencedType.CanSpecifyPrecision && facets.NumericPrecision != null)
                {
                    throw new ArgumentException($"Cannot specify precision for {dataTypeName} data type");
                }

                if (!ReferencedType.CanSpecifyScale && facets.NumericScale != null)
                {
                    throw new ArgumentException($"Cannot specify scale for {dataTypeName} data type");
                }
            }
        }
    }

    public class typeref<t> : typeref<typeref<t>, t>
        where t : sxc.ISqlType
    {
        public static implicit operator typeref(typeref<t> r)
            => new typeref(r.descriptor);

        public static implicit operator SqlTypeDescriptor(typeref<t> r)
            => r.descriptor;

        public typeref(SqlTypeDescriptor descriptor)
            : base(descriptor)
        {

        }

        public typeref(t type, bool IsNullable)
            : base(type, IsNullable, null, null, null)
        {

        }

        public typeref(t type, bool nullable, int? maxlen)
            : base(type, nullable, maxlen, null, null)
        {

        }

        public typeref(t ReferencedType, SqlDataFacets Facets)
            : base(ReferencedType, Facets)
        {

        }

        public typeref(t type, bool nullable = true, int? maxlen = null, 
            byte? precision = null, byte? scale = null)
                : base(type, nullable, maxlen, precision, scale)
        {

        }

        public typeref(SqlTypeName name, bool nullable, int? maxlen = null,
                byte? precision = null, byte? scale = null) 
                    : base(name, nullable, maxlen, precision, scale)
        {

        }

        public SqlTypeDescriptor descriptor
            => new SqlTypeDescriptor(this);

        public override sxc.data_type_ref retype(SqlTypeDescriptor descriptor)
            => new typeref<t>(descriptor);
    }

    public class typeref : typeref<typeref, sxc.ISqlType>
    {

        public typeref(sxc.ISqlType ReferencedType, bool IsNullable)
            : base(ReferencedType, IsNullable, null, null, null)
        {

        }

        public typeref(sxc.ISqlType ReferencedType, bool IsNullable, int? MaxLength)
            : base(ReferencedType, IsNullable, MaxLength, null, null)
        {

        }

        public typeref(sxc.ISqlType ReferencedType, bool IsNullable = true,
                byte? NumericPrecision = null, byte? NumericScale = null)
                    : base(ReferencedType, IsNullable, null, NumericPrecision, NumericScale)
        {

        }

        public typeref(sxc.ISqlType ReferencedType, bool IsNullable = true, int? MaxLength = null,
            byte? NumericPrecision = null, byte? NumericScale = null)
                : base(ReferencedType, IsNullable, MaxLength, NumericPrecision, NumericScale)
        {

        }

        public typeref(sxc.ISqlType ReferencedType, SqlDataFacets Facets)
            : base(ReferencedType, Facets)
        {

        }

        public typeref(SqlTypeDescriptor descriptor)
            : base(descriptor)
        {

        }

        public typeref(SqlTypeName ReferencedTypeName, bool IsNullable, int? MaxLength = null,
                byte? NumericPrecision = null, byte? NumericScale = null)
                    : base(ReferencedTypeName, IsNullable, MaxLength, NumericPrecision, NumericScale)
        {

        }

        public override sxc.data_type_ref retype(SqlTypeDescriptor descriptor)
            => new typeref(descriptor);
    }


}
