////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class EndConversationStatement : TSqlStatement, ISqlTDomStatement
    {
        public ScalarExpression Conversation
        {
            get;
            set;
        }

        public bool WithCleanup
        {
            get;
            set;
        }

        public ValueExpression ErrorCode
        {
            get;
            set;
        }

        public ValueExpression ErrorDescription
        {
            get;
            set;
        }
    }
}