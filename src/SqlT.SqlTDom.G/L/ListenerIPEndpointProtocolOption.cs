////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ListenerIPEndpointProtocolOption : EndpointProtocolOption, ISqlTDomOption
    {
        public bool IsAll
        {
            get;
            set;
        }

        public Literal IPv6
        {
            get;
            set;
        }

        public IPv4 IPv4PartOne
        {
            get;
            set;
        }

        public IPv4 IPv4PartTwo
        {
            get;
            set;
        }
    }
}