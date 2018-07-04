//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{  
    /// <summary>
    /// Specifies the name of a Alias
    /// </summary>
    public sealed class SqlAliasName : SqlName<SqlAliasName>
    {
        public static new SqlAliasName Parse(string s)
            => FromParts(Componetize(s));

        public static implicit operator SqlAliasName(string s)
            => new SqlAliasName(s);

        public static implicit operator SqlAliasName((string alias, bool quoted) xy)
            => new SqlAliasName(xy.alias,xy.quoted);

        public static SqlAliasName FromParts(params string[] parts)
            => new SqlAliasName(parts.Length != 0 ? parts[0] : string.Empty);

        public static implicit operator string(SqlAliasName x)
            => x.FullName;

        public SqlAliasName()
            : base(string.Empty)
        { }
       
        public SqlAliasName(string value, bool quoted = false)
            : base(quoted, value)
        {

        }

        public override string FullName
            => CreateFullName(false);
    }
}