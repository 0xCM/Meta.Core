////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public Identifier MethodName
        {
            get;
            set;
        }

        public IList<ScalarExpression> Parameters
        {
            get;
            set;
        }
    }
}