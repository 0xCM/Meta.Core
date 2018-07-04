////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FederationScheme : TSqlFragment, ISqlTDomElement
    {
        public Identifier DistributionName
        {
            get;
            set;
        }

        public Identifier ColumnName
        {
            get;
            set;
        }
    }
}