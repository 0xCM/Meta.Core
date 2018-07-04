////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class Permission : TSqlFragment, ISqlTDomElement
    {
        public IList<Identifier> Identifiers
        {
            get;
            set;
        }

        public IList<Identifier> Columns
        {
            get;
            set;
        }
    }
}