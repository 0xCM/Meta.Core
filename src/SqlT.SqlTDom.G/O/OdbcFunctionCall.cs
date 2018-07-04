////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OdbcFunctionCall : PrimaryExpression, ISqlTDomElement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public bool ParametersUsed
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