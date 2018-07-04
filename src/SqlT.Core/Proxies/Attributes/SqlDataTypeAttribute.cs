namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    public abstract class SqlDataTypeAttribute : Attribute
    {

        static SqlDataTypeAttribute ReadFromMember(MemberInfo m)
            => m.GetCustomAttribute<SqlDataTypeAttribute>();

        public static SqlDataTypeAttribute ReadFrom(PropertyInfo p)
            => ReadFromMember(p);

        public static SqlDataTypeAttribute ReadFrom(FieldInfo f)
            => ReadFromMember(f);

        public static SqlDataTypeAttribute ReadFrom(ParameterInfo p)
            => p.GetCustomAttribute<SqlDataTypeAttribute>();

        public static SqlDataTypeAttribute ReadFromReturn(MethodInfo p)
            => p.ReturnParameter.GetCustomAttribute<SqlDataTypeAttribute>();

        public SqlDataTypeAttribute(string DataTypeName, bool? IsNullable, int? Length = null, byte? Precision = null, byte? Scale = null)
        {
            this.DataTypeName = DataTypeName;
            this.BaseTypeName = DataTypeName;
            this.IsNullable = IsNullable;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public SqlDataTypeAttribute(string DataTypeName, string BaseTypeName, bool? IsNullable, int? Length = null, byte? Precision = null, byte? Scale = null)
        {
            this.DataTypeName = DataTypeName;
            this.BaseTypeName = BaseTypeName;
            this.IsNullable = IsNullable;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public string DataTypeName { get; }
        public string BaseTypeName { get; }
        public bool? IsNullable { get; }
        public int? Length { get; }
        public byte? Precision { get; }
        public byte? Scale { get; }

        public virtual bool IsIntrinsic
            => BaseTypeName == DataTypeName;

        public SqlTypeInfo TypeDescription
            => new SqlTypeInfo
                    (
                        DataTypeName,
                        BaseTypeName,
                        IsNullable,
                        Length,
                        Precision,
                        Scale
                    );


    }


}
