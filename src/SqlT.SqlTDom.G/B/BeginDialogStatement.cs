////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BeginDialogStatement : TSqlStatement, ISqlTDomStatement
    {
        public bool IsConversation
        {
            get;
            set;
        }

        public VariableReference Handle
        {
            get;
            set;
        }

        public IdentifierOrValueExpression InitiatorServiceName
        {
            get;
            set;
        }

        public ValueExpression TargetServiceName
        {
            get;
            set;
        }

        public ValueExpression InstanceSpec
        {
            get;
            set;
        }

        public IdentifierOrValueExpression ContractName
        {
            get;
            set;
        }

        public IList<DialogOption> Options
        {
            get;
            set;
        }
    }
}