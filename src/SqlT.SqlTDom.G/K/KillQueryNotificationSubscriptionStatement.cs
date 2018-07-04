////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class KillQueryNotificationSubscriptionStatement : TSqlStatement, ISqlTDomStatement
    {
        public Literal SubscriptionId
        {
            get;
            set;
        }

        public bool All
        {
            get;
            set;
        }
    }
}