////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class SecurityPolicyStatement : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public bool NotForReplication
        {
            get;
            set;
        }

        public IList<SecurityPolicyOption> SecurityPolicyOptions
        {
            get;
            set;
        }

        public IList<SecurityPredicateAction> SecurityPredicateActions
        {
            get;
            set;
        }

        public SecurityPolicyActionType ActionType
        {
            get;
            set;
        }
    }
}