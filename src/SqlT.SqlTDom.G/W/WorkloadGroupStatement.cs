////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class WorkloadGroupStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<WorkloadGroupParameter> WorkloadGroupParameters
        {
            get;
            set;
        }

        public Identifier PoolName
        {
            get;
            set;
        }

        public Identifier ExternalPoolName
        {
            get;
            set;
        }
    }
}