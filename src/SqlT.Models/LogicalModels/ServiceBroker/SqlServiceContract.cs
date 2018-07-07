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

    [SqlElementType(SqlElementTypeNames.Contract)]
    public sealed class SqlServiceContract : SqlElement<SqlServiceContract, SqlBrokerContractName>
    {

        public SqlServiceContract(SqlBrokerContractName Name, SqlElementDescription Description) 
            : this(Name, null, Description)
        {

        }

        public SqlServiceContract(SqlBrokerContractName Name,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Description = null,
            bool IsIntrinsic = false
            ) : base(Name, Description, Properties, IsIntrinsic)
        {

        }
    }

    public sealed class SqlServiceContracts : SyntaxList<SqlServiceContracts, SqlServiceContract>
    {
        public static implicit operator SqlServiceContracts(SqlServiceContract[] Contracts)
            => new SqlServiceContracts(Contracts);

        public SqlServiceContracts()
        { }

        public SqlServiceContracts(SqlServiceContract[] Contracts)
            : base(Contracts)
        { }
    }
}
