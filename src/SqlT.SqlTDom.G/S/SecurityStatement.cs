////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class SecurityStatement : TSqlStatement, ISqlTDomStatement
    {
        public IList<Permission> Permissions
        {
            get;
            set;
        }

        public SecurityTargetObject SecurityTargetObject
        {
            get;
            set;
        }

        public IList<SecurityPrincipal> Principals
        {
            get;
            set;
        }

        public Identifier AsClause
        {
            get;
            set;
        }
    }
}