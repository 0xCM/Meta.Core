////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class GetConversationGroupStatement : WaitForSupportedStatement, ISqlTDomStatement
    {
        public VariableReference GroupId
        {
            get;
            set;
        }

        public SchemaObjectName Queue
        {
            get;
            set;
        }
    }
}