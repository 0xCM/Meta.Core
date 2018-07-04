////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExecutableProcedureReference : ExecutableEntity, ISqlTDomElement
    {
        public ProcedureReferenceName ProcedureReference
        {
            get;
            set;
        }

        public AdHocDataSource AdHocDataSource
        {
            get;
            set;
        }
    }
}