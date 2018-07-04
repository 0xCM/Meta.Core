////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class IdentifierOrValueExpression : TSqlFragment, ISqlTDomExpression
    {
        public string Value
        {
            get;
            set;
        }

        public Identifier Identifier
        {
            get;
            set;
        }

        public ValueExpression ValueExpression
        {
            get;
            set;
        }
    }
}