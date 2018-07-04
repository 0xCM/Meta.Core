////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BrokerPriorityParameter : TSqlFragment, ISqlTDomElement
    {
        public BrokerPriorityParameterSpecialType IsDefaultOrAny
        {
            get;
            set;
        }

        public BrokerPriorityParameterType ParameterType
        {
            get;
            set;
        }

        public IdentifierOrValueExpression ParameterValue
        {
            get;
            set;
        }
    }
}