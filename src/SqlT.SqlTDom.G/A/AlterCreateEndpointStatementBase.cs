////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class AlterCreateEndpointStatementBase : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public EndpointState State
        {
            get;
            set;
        }

        public EndpointAffinity Affinity
        {
            get;
            set;
        }

        public EndpointProtocol Protocol
        {
            get;
            set;
        }

        public IList<EndpointProtocolOption> ProtocolOptions
        {
            get;
            set;
        }

        public EndpointType EndpointType
        {
            get;
            set;
        }

        public IList<PayloadOption> PayloadOptions
        {
            get;
            set;
        }
    }
}