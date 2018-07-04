////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ProcedureReferenceName : TSqlFragment, ISqlTDomElement
    {
        public ProcedureReference ProcedureReference
        {
            get;
            set;
        }

        public VariableReference ProcedureVariable
        {
            get;
            set;
        }
    }
}