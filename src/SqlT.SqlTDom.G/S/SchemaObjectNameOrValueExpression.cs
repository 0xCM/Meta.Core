////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SchemaObjectNameOrValueExpression : TSqlFragment, ISqlTDomExpression
    {
        public SchemaObjectName SchemaObjectName
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