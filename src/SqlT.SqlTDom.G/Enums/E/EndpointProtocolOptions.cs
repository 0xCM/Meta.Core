////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum EndpointProtocolOptions : int
    {
        None = 0,
        HttpAuthenticationRealm = 1,
        HttpAuthentication = 2,
        HttpClearPort = 4,
        HttpCompression = 8,
        HttpDefaultLogonDomain = 16,
        HttpPath = 32,
        HttpPorts = 64,
        HttpSite = 128,
        HttpSslPort = 256,
        HttpOptions = 511,
        TcpListenerIP = 512,
        TcpListenerPort = 1024,
        TcpOptions = 1536
    }
}