////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DeviceInfo : TSqlFragment, ISqlTDomElement
    {
        public IdentifierOrValueExpression LogicalDevice
        {
            get;
            set;
        }

        public ValueExpression PhysicalDevice
        {
            get;
            set;
        }

        public DeviceType DeviceType
        {
            get;
            set;
        }
    }
}