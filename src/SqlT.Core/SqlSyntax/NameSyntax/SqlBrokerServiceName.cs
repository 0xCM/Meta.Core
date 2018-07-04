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

    public sealed class SqlBrokerServiceName : SqlName<SqlBrokerServiceName>, ISimpleSqlName
    {
        public static readonly string UriPartIdentifier = "sbservice";

        public new static SqlBrokerServiceName Parse(string s)
            => new SqlBrokerServiceName(Componetize(s).FirstOrDefault());

        public static implicit operator SqlBrokerServiceName(string LocalName)
            => new SqlBrokerServiceName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlBrokerServiceName(string identifier)
            : base(true, identifier)
        {

        }

        public SqlBrokerServiceName(bool quote, string identifier)
            : base(quote, identifier)
        {

        }


        public SqlBrokerServiceName()
            : this(string.Empty)
        { }


        public override string FullName
            => CreateFullName(Quoted);

    }


}