////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SendStatement : TSqlStatement, ISqlTDomStatement
    {
        public IList<ScalarExpression> ConversationHandles
        {
            get;
            set;
        }

        public IdentifierOrValueExpression MessageTypeName
        {
            get;
            set;
        }

        public ScalarExpression MessageBody
        {
            get;
            set;
        }
    }
}