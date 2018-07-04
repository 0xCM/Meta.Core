////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class AvailabilityGroupStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<AvailabilityGroupOption> Options
        {
            get;
            set;
        }

        public IList<Identifier> Databases
        {
            get;
            set;
        }

        public IList<AvailabilityReplica> Replicas
        {
            get;
            set;
        }
    }
}