////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class EventSessionStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public EventSessionScope SessionScope
        {
            get;
            set;
        }

        public IList<EventDeclaration> EventDeclarations
        {
            get;
            set;
        }

        public IList<TargetDeclaration> TargetDeclarations
        {
            get;
            set;
        }

        public IList<SessionOption> SessionOptions
        {
            get;
            set;
        }
    }
}