////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FunctionCall : PrimaryExpression, ISqlTDomElement
    {
        public CallTarget CallTarget
        {
            get;
            set;
        }

        public Identifier FunctionName
        {
            get;
            set;
        }

        public IList<ScalarExpression> Parameters
        {
            get;
            set;
        }

        public UniqueRowFilter UniqueRowFilter
        {
            get;
            set;
        }

        public OverClause OverClause
        {
            get;
            set;
        }

        public WithinGroupClause WithinGroupClause
        {
            get;
            set;
        }
    }
}