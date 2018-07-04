//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;
    using SqlT.Syntax;

    public sealed class SqlExpressionName : SqlExpressionName<SqlExpressionName>
    {        

        public static new SqlExpressionName Parse(string s)
            => new SqlExpressionName(s);

        public static implicit operator SqlExpressionName(string x)
            => new SqlExpressionName(x);

        public SqlExpressionName(ISimpleSqlName name)
            : base(name)
        { }


        public SqlExpressionName(string Value)
            : base(Value)
        {

        }

        public SqlExpressionName()
            : this(string.Empty)
        { }

        public override string FullName
            => CreateFullName(false);


    }


}