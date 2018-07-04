////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AuditTarget : TSqlFragment, ISqlTDomElement
    {
        public AuditTargetKind TargetKind
        {
            get;
            set;
        }

        public IList<AuditTargetOption> TargetOptions
        {
            get;
            set;
        }
    }
}