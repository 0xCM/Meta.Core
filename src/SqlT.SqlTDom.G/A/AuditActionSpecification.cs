////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AuditActionSpecification : AuditSpecificationDetail, ISqlTDomElement
    {
        public IList<DatabaseAuditAction> Actions
        {
            get;
            set;
        }

        public IList<SecurityPrincipal> Principals
        {
            get;
            set;
        }

        public SecurityTargetObject TargetObject
        {
            get;
            set;
        }
    }
}