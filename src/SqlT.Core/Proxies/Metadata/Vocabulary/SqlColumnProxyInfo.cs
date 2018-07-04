//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Reflection;

    public class SqlColumnProxyInfo : SqlProxyInfo
    {
        public SqlColumnProxyInfo
            (object ClrElement, 
            SqlColumnName ColumnName, 
            int Position, 
            SqlTypeInfo SqlType, 
            SqlColumnDocumentation Documentation = null
            )
            : base(SqlProxyKind.Column, ClrElement, Documentation ?? SqlColumnDocumentation.Empty)
        {
            this.ColumnName = ColumnName;
            this.Position = Position;
            this.SqlType = SqlType;
        }

        protected SqlColumnProxyInfo
            (SqlProxyKind ProxyKind, 
            object ClrElement, 
            SqlColumnName ColumnName, 
            int Position, 
            SqlTypeInfo SqlType, 
            SqlColumnDocumentation Documentation = null
            ) : base(ProxyKind, ClrElement, Documentation)
        {

            this.ColumnName = ColumnName;
            this.Position = Position;
            this.SqlType = SqlType;
        }

        public SqlColumnName ColumnName { get; }

        public int Position { get; }

        public SqlTypeInfo SqlType { get; }

        public new SqlColumnDocumentation Documentation
            => base.Documentation as SqlColumnDocumentation;


        string ClrTypeName
        {
            get
            {
                var type = (ClrElement as PropertyInfo)?.PropertyType ?? (ClrElement as FieldInfo)?.FieldType;
                if (type == null)
                    return String.Empty;

                var typeName = type.IsNullableType()
                             ? $"{type.GetGenericArguments()[0].Name}?"
                             : type.Name;

                return typeName;

            }
        }

        public override string ToString()
            => $"{Position.ToString().PadLeft(2, '0')} {ColumnName} : {ClrTypeName}";

        /// <summary>
        /// Get the CLR type of the column being proxied
        /// </summary>
        public override Type RuntimeType
            => (ClrElement as PropertyInfo)?.PropertyType
            ?? (ClrElement as FieldInfo)?.FieldType;

        /// <summary>
        /// Gets the name of the CLR member that represents the column
        /// </summary>
        public string RuntimeName
            => (ClrElement as PropertyInfo)?.Name
            ?? (ClrElement as FieldInfo)?.Name;

        public SqlColumnRole Role
            => new SqlColumnRole(ColumnName, Documentation?.RoleType ?? SqlColumnRoleTypes.UnclassifiedRole);
    }

}