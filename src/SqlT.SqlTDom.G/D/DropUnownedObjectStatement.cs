////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class DropUnownedObjectStatement : TSqlStatement, ISqlTDomDropStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public bool IsIfExists
        {
            get;
            set;
        }
    }
}