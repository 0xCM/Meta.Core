////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class PartitionFunctionCall : PrimaryExpression, ISqlTDomElement
    {
        public Identifier DatabaseName
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
    }
}