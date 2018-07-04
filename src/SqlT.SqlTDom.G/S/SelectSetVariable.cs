////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SelectSetVariable : SelectElement, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public ScalarExpression Expression
        {
            get;
            set;
        }

        public AssignmentKind AssignmentKind
        {
            get;
            set;
        }
    }
}