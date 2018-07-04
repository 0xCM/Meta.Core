////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AssignmentSetClause : SetClause, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public ColumnReferenceExpression Column
        {
            get;
            set;
        }

        public ScalarExpression NewValue
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