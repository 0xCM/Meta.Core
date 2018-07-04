//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    [SqlElementType(SqlElementTypeNames.Service)]
    public sealed class SqlBrokerService : SqlElement<SqlBrokerService, SqlBrokerServiceName>
    {

        public SqlBrokerService(SqlBrokerServiceName Name, SqlElementDescription Description) 
            : this(Name, null, Description)
        {

        }

        public SqlBrokerService(SqlBrokerServiceName Name,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Description = null            
            ) : base(Name, Description, Properties)
        {

        }
    }

    public sealed class SqlBrokerServices : SyntaxList<SqlBrokerServices, SqlBrokerService>
    {
        public static implicit operator SqlBrokerServices(SqlBrokerService[] Contracts)
            => new SqlBrokerServices(Contracts);

        public SqlBrokerServices()
        { }

        public SqlBrokerServices(SqlBrokerService[] Contracts)
            : base(Contracts)
        { }
    }
}
