////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateEventNotificationStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public EventNotificationObjectScope Scope
        {
            get;
            set;
        }

        public bool WithFanIn
        {
            get;
            set;
        }

        public IList<EventTypeGroupContainer> EventTypeGroups
        {
            get;
            set;
        }

        public Literal BrokerService
        {
            get;
            set;
        }

        public Literal BrokerInstanceSpecifier
        {
            get;
            set;
        }
    }
}