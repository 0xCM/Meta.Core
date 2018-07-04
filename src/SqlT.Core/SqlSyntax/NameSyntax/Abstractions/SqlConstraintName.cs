//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;

    /// <summary>
    /// Defines a Constraint name
    /// </summary>
    public abstract class SqlConstraintName<T> : SqlObjectName<T>
        where T : SqlConstraintName<T>, new()
    {

        protected SqlConstraintName()
        { }


        protected SqlConstraintName(params string[] parts)
            : base(parts)
        { }

        public SqlConstraintName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlConstraintName(ICompositeSqlName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        {

        }

        public SqlConstraintName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlConstraintName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlConstraintName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }

        public override string FullName
            => CreateFullName(false);

    }

    //public sealed class SqlConstraintName : SqlConstraintName<SqlConstraintName>
    //{
    //    public SqlConstraintName()
    //    { }


    //    SqlConstraintName(params string[] parts)
    //        : base(parts)
    //    { }

    //    public SqlConstraintName(string LocalName)
    //        : base(LocalName)
    //    {

    //    }

    //    public SqlConstraintName(sxc.composite_name SqlName)
    //        : base(SqlName)
    //    {

    //    }

    //    public SqlConstraintName(SqlSchemaName SchemaName, string LocalName)
    //        : base(SchemaName, LocalName)
    //    { }

    //    public SqlConstraintName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
    //        : base(DatabaseName, SchemaName, LocalName)
    //    { }

    //    public SqlConstraintName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
    //        : base(ServerName, DatabaseName, SchemaName, LocalName)
    //    { }

    //    public override string FullName
    //        => CreateFullName(false);
    //}
}
