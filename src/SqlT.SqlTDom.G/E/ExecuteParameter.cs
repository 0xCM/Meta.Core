////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExecuteParameter : TSqlFragment, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public ScalarExpression ParameterValue
        {
            get;
            set;
        }

        public bool IsOutput
        {
            get;
            set;
        }
    }
}