//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;
    using System.Linq;

    using SqlT.Syntax;

    
    public sealed class SqlApplicationRoleName : SqlName<SqlApplicationRoleName>, ISimpleSqlName
    {

        public static readonly string UriPartIdentifier = "approle";

        public new static SqlApplicationRoleName Parse(string s)
            => new SqlApplicationRoleName(Componetize(s).FirstOrDefault());

        public static implicit operator SqlApplicationRoleName(string LocalName)
            => new SqlApplicationRoleName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlApplicationRoleName(string identifier)
            : base(true, identifier)
        {

        }

        public SqlApplicationRoleName(bool quote, string identifier)
            : base(quote, identifier)
        {

        }


        public SqlApplicationRoleName()
            : this(string.Empty)
        { }


        public override string FullName
            => CreateFullName(Quoted);

    }


}