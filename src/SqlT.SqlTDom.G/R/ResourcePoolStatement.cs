////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ResourcePoolStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<ResourcePoolParameter> ResourcePoolParameters
        {
            get;
            set;
        }
    }
}