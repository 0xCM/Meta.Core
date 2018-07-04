////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExternalResourcePoolAffinitySpecification : TSqlFragment, ISqlTDomElement
    {
        public ExternalResourcePoolAffinityType AffinityType
        {
            get;
            set;
        }

        public Literal ParameterValue
        {
            get;
            set;
        }

        public bool IsAuto
        {
            get;
            set;
        }

        public IList<LiteralRange> PoolAffinityRanges
        {
            get;
            set;
        }
    }
}