////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase, ISqlTDomStatement
    {
        public ProcedureReference ProcedureReference
        {
            get;
            set;
        }

        public bool IsForReplication
        {
            get;
            set;
        }

        public IList<ProcedureOption> Options
        {
            get;
            set;
        }
    }
}