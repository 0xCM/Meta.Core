////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MoveConversationStatement : TSqlStatement, ISqlTDomStatement
    {
        public ScalarExpression Conversation
        {
            get;
            set;
        }

        public ScalarExpression Group
        {
            get;
            set;
        }
    }
}