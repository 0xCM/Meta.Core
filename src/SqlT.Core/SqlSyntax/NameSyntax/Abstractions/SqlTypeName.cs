//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;

    using sxc = Syntax.contracts;

    public abstract class SqlTypeName<N> : SqlObjectName<N>, sxc.type_name
        where N : SqlTypeName<N>, new()
    {
        protected SqlTypeName()
        {

        }

        protected SqlTypeName(params string[] parts)
            : base(parts)
        { }

        protected SqlTypeName(ICompositeSqlName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        {

        }

        protected SqlTypeName(string LocalName)
            : base(LocalName)
        {

        }

        protected SqlTypeName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        protected SqlTypeName(SqlDatabaseName ServerName, string SchemaNamePart, string LocalName)
            : base(ServerName, SchemaNamePart, LocalName)
        { }

        protected SqlTypeName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }

        public override bool Equals(object other)
        {
            if (!IsComparable(other))
                return false;

            if (base.Equals(other))
                return true;

            var left = this;
            var right = (other as ICompositeSqlName).AsTypeName();
            if (left.SchemaName.IsSystemSchema || right.SchemaName.IsSystemSchema)
                return string.Compare(left.UnqualifiedName, right.UnqualifiedName, true) == 0;
            else if
                (SqlDataTypeNames.Contains(left.UnqualifiedName) || SqlDataTypeNames.Contains(right.UnqualifiedName))
                return string.Compare(left.UnqualifiedName, right.UnqualifiedName, true) == 0;

            return false;
        }

        public override int GetHashCode()
            => base.GetHashCode();
    }

    public sealed class SqlTypeName : SqlTypeName<SqlTypeName>,  sxc.type_name
    {
        public static new SqlTypeName Parse(string s)
            => new SqlTypeName(Componetize(s));

        public static SqlTypeName FromParts(params string[] parts)
            => new SqlTypeName(parts);
    
        public static implicit operator SqlTypeName(string s)
            => Parse(s);

        public SqlTypeName()
        { }

        protected override SqlTypeName CreateFromParts(params string[] parts)
            => new SqlTypeName(parts);

        SqlTypeName(params string[] parts)
            : base(parts)
        { }

        public SqlTypeName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlTypeName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlTypeName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlTypeName(SqlServerName Servername, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(Servername, DatabaseName, SchemaName, LocalName)
        { }


        public SqlTypeName(ICompositeSqlName SqlName, bool Quoted = true)
            : base(SqlName, Quoted)
        {

        }
    }
}
