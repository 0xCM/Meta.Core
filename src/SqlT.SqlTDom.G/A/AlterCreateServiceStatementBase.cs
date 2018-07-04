////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class AlterCreateServiceStatementBase : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public SchemaObjectName QueueName
        {
            get;
            set;
        }

        public IList<ServiceContract> ServiceContracts
        {
            get;
            set;
        }
    }
}