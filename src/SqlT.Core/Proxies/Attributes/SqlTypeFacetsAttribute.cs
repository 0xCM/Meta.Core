//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public class SqlTypeFacetsAttribute : Attribute
    {
        SqlTypeFacetsAttribute(string TypeName)
        {
            this.TypeName = TypeName;
        }


        SqlTypeFacetsAttribute(string TypeName, string UnderlyingTypeName)
            : this(TypeName)
        {
            this.UnderlyingTypeName = UnderlyingTypeName;                
        }

        public SqlTypeFacetsAttribute(string TypeName, bool IsNullable)
            : this(TypeName)
        {
            this.IsNullable = IsNullable;
        }

        public SqlTypeFacetsAttribute(string TypeName, string UnderlyingTypeName, bool IsNullable)
            : this(TypeName, UnderlyingTypeName)
        {
            this.IsNullable = IsNullable;
        }


        public SqlTypeFacetsAttribute(string TypeName, bool IsNullable, int Precision, int Scale)
            : this(TypeName, IsNullable)
        {
            this.Precision = Precision != -1 ? (byte?)Precision : null;
            this.Scale = Scale != -1 ? (byte?)Scale : 0;
        }

        public SqlTypeFacetsAttribute(string TypeName, string UnderlyingTypeNane, bool IsNullable, int Precision, int Scale)
            : this(TypeName, UnderlyingTypeNane, IsNullable)
        {
            this.Precision = Precision != -1 ? (byte?)Precision : null;
            this.Scale = Scale != -1 ? (byte?)Scale : 0;
        }

        public SqlTypeFacetsAttribute(string TypeName, bool IsNullable, int MaxLength)
            : this(TypeName, IsNullable)
        {
            this.MaxLength = MaxLength != -1 ? (int?)MaxLength : null;
        }

        public SqlTypeFacetsAttribute(string TypeName, string UnderlyingTypeName, bool IsNullable, int MaxLength)
            : this(TypeName, UnderlyingTypeName, IsNullable)
        {
            this.MaxLength = MaxLength != -1 ? (int?)MaxLength : null;
        }

        public string TypeName { get; }

        public string UnderlyingTypeName { get; }

        public bool? IsNullable { get; }

        public int? MaxLength { get; }

        public byte? Precision { get; }

        public byte? Scale { get; }


        public SqlTypeInfo DescribeType()
            => new SqlTypeInfo
            {
                TypeName = TypeName,
                BaseTypeName = UnderlyingTypeName,
                IsNullable = IsNullable,
                Length = MaxLength,
                Precision = Precision,
                Scale = Scale
            };

    }
}