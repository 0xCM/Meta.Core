////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SetVariableStatement : TSqlStatement, ISqlTDomStatement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public SeparatorType SeparatorType
        {
            get;
            set;
        }

        public Identifier Identifier
        {
            get;
            set;
        }

        public bool FunctionCallExists
        {
            get;
            set;
        }

        public IList<ScalarExpression> Parameters
        {
            get;
            set;
        }

        public ScalarExpression Expression
        {
            get;
            set;
        }

        public CursorDefinition CursorDefinition
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