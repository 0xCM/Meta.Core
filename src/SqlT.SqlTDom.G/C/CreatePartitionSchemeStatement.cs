////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreatePartitionSchemeStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Identifier PartitionFunction
        {
            get;
            set;
        }

        public bool IsAll
        {
            get;
            set;
        }

        public IList<IdentifierOrValueExpression> FileGroups
        {
            get;
            set;
        }
    }
}