////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class QueueStatement : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public IList<QueueOption> QueueOptions
        {
            get;
            set;
        }
    }
}