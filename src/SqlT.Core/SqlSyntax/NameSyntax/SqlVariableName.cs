//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;
    using SqlT.Syntax;

    public sealed class SqlVariableName : SqlName<SqlVariableName>, ISimpleSqlName
    {
        public static implicit operator SqlVariableName(string name)
            => new SqlVariableName(name);

        public static new SqlVariableName Parse(string s)
            => new SqlVariableName(s);

        public static SqlVariableName FromParts(params string[] parts)
            => new SqlVariableName(parts.Length != 0 ? parts[0] : string.Empty);

        public static implicit operator string(SqlVariableName x)
            => x.FullName;

        public SqlVariableName()
            : base(string.Empty)
        { }

        
        public SqlVariableName(string value)
            : base(value.StartsWith("@") ? value : $"@{value}")
        {

        }

        public override string FullName
            => CreateFullName(false);
    }



}