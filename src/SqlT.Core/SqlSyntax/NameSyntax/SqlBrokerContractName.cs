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

    public sealed class SqlBrokerContractName : SqlName<SqlBrokerContractName>
    {

        public static readonly string UriPartIdentifier = "sbcontract";

        public new static SqlBrokerContractName Parse(string s)
            => new SqlBrokerContractName(Componetize(s).FirstOrDefault());

        public static implicit operator SqlBrokerContractName(string LocalName)
            => new SqlBrokerContractName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlBrokerContractName(string identifier)
            : base(true, identifier)
        {

        }

        public SqlBrokerContractName(bool quote, string identifier)
            : base(quote, identifier)
        {

        }



        public SqlBrokerContractName()
            : this(string.Empty)
        { }


        public override string FullName
            => CreateFullName(Quoted);

       

    }


}