////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ResourcePoolAffinitySpecification : TSqlFragment, ISqlTDomElement
    {
        public ResourcePoolAffinityType AffinityType
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