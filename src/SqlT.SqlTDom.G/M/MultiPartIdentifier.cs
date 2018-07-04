////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MultiPartIdentifier : TSqlFragment, ISqlTDomElement
    {
        public int Count
        {
            get;
            set;
        }

        public IList<Identifier> Identifiers
        {
            get;
            set;
        }
    }
}