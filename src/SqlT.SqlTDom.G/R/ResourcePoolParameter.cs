////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ResourcePoolParameter : TSqlFragment, ISqlTDomElement
    {
        public ResourcePoolParameterType ParameterType
        {
            get;
            set;
        }

        public Literal ParameterValue
        {
            get;
            set;
        }

        public ResourcePoolAffinitySpecification AffinitySpecification
        {
            get;
            set;
        }
    }
}