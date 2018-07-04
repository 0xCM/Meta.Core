////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class FunctionStatementBody : ProcedureStatementBodyBase, ISqlTDomStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public FunctionReturnType ReturnType
        {
            get;
            set;
        }

        public IList<FunctionOption> Options
        {
            get;
            set;
        }

        public OrderBulkInsertOption OrderHint
        {
            get;
            set;
        }
    }
}