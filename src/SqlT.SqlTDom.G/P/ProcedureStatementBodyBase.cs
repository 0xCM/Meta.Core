////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ProcedureStatementBodyBase : TSqlStatement, ISqlTDomStatement
    {
        public IList<ProcedureParameter> Parameters
        {
            get;
            set;
        }

        public StatementList StatementList
        {
            get;
            set;
        }

        public MethodSpecifier MethodSpecifier
        {
            get;
            set;
        }
    }
}