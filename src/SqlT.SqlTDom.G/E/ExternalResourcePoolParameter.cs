////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExternalResourcePoolParameter : TSqlFragment, ISqlTDomElement
    {
        public ExternalResourcePoolParameterType ParameterType
        {
            get;
            set;
        }

        public Literal ParameterValue
        {
            get;
            set;
        }

        public ExternalResourcePoolAffinitySpecification AffinitySpecification
        {
            get;
            set;
        }
    }
}