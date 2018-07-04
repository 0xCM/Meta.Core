////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TriggerObject : TSqlFragment, ISqlTDomElement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public TriggerScope TriggerScope
        {
            get;
            set;
        }
    }
}