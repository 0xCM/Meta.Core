//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;

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
