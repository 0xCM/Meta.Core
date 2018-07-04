////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class IdentityOptions : TSqlFragment, ISqlTDomElement
    {
        public ScalarExpression IdentitySeed
        {
            get;
            set;
        }

        public ScalarExpression IdentityIncrement
        {
            get;
            set;
        }

        public bool IsIdentityNotForReplication
        {
            get;
            set;
        }
    }
}