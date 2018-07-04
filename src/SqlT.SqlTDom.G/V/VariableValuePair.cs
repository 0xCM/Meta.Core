////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class VariableValuePair : TSqlFragment, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public ScalarExpression Value
        {
            get;
            set;
        }

        public bool IsForUnknown
        {
            get;
            set;
        }
    }
}