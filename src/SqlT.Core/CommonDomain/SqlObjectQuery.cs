//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public abstract class SqlObjectQuery<N> 
        where N : SqlObjectName<N>, new()
    {
        
        public static bool operator ==(SqlObjectQuery<N> x, SqlObjectQuery<N> y)
            => (x is null || y is null)
            ? false
            : x.Equals(y);

        public static bool operator !=(SqlObjectQuery<N> x, SqlObjectQuery<N> y)
            => !(x == y);

        protected SqlObjectQuery(N SourceName, ISqlScript Script, (string name, string value)? Filter = null)
        {
            this.SourceName = SourceName;
            this.Script = Script;
            this.Filter = Filter;
        }

        public N SourceName { get; }


        public ISqlScript Script { get; }

        public (string name, string value)? Filter { get; }

        public string FilterName
            => Filter?.name ?? string.Empty;

        public string FilterValue
            => Filter?.value ?? string.Empty;
            

        public bool IsFiltered
            => Filter.HasValue;

        public override string ToString()
        {
            return Script.ScriptText;
        }

        public override int GetHashCode()
            => Script.ScriptText.GetHashCode();

        public override bool Equals(object obj)
            => Script.ScriptText == (obj as SqlObjectQuery<N>)?.Script.ScriptText;
    }


    public abstract class SqlObjectQuery<Q, N> : SqlObjectQuery<N>
        where N : SqlObjectName<N>, new()
        where Q : SqlObjectQuery<Q,N>
    {

        protected SqlObjectQuery(N SourceName, ISqlScript Script, (string name, string value)? Filter = null)
            : base(SourceName, Script, Filter)
        {
        }
    }

    public abstract class SqlTableQuery<Q> : SqlObjectQuery<Q, SqlTableName>
        where Q : SqlTableQuery<Q>

    {
        
        protected SqlTableQuery(SqlTableName SourceName, ISqlScript Script, (string name, string value)? Filter = null)
            : base(SourceName, Script, Filter)
        {
        }

    }

    public sealed class SqlTableQuery : SqlObjectQuery<SqlTableName>
    {
        public SqlTableQuery(SqlTableName SourceName, ISqlScript Script, (string name, string value)? Filter = null)
            : base(SourceName, Script, Filter)
        { }


        public SqlTableQuery(SqlTableName SourceName)
            : base(SourceName, new SqlScript(SourceName.Format(true),  $"select * from {SourceName}"))
        {

        }

    }

    
}
