//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using N = SqlUserName;
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    public sealed class SqlUserName : SqlName<N>
    {

        public static new N Parse(string Identifier)
            => new N(Identifier);


        public static implicit operator N(string Identifier)
            => Parse(Identifier);


        public SqlUserName()
            : this(string.Empty)
        {

        }

        public SqlUserName(string Identifier)
            : base(Identifier)
        {

        }

        public SqlUserName(ICompositeSqlName SqlName)
            : base(SqlName)
        {

        }

        public override string FullName
            => CreateFullName(false);

    }
}
