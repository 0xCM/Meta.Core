////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AuthenticationTypes : int
    {
        None = 0,
        Basic = 1,
        Digest = 2,
        Integrated = 4,
        Ntlm = 8,
        Kerberos = 16
    }
}