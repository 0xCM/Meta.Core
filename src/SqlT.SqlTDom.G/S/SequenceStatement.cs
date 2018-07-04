////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class SequenceStatement : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public IList<SequenceOption> SequenceOptions
        {
            get;
            set;
        }
    }
}