////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ReceiveStatement : WaitForSupportedStatement, ISqlTDomStatement
    {
        public ScalarExpression Top
        {
            get;
            set;
        }

        public IList<SelectElement> SelectElements
        {
            get;
            set;
        }

        public SchemaObjectName Queue
        {
            get;
            set;
        }

        public VariableTableReference Into
        {
            get;
            set;
        }

        public ValueExpression Where
        {
            get;
            set;
        }

        public bool IsConversationGroupIdWhere
        {
            get;
            set;
        }
    }
}