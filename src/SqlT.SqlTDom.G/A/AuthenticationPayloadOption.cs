////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AuthenticationPayloadOption : PayloadOption, ISqlTDomOption
    {
        public AuthenticationProtocol Protocol
        {
            get;
            set;
        }

        public Identifier Certificate
        {
            get;
            set;
        }

        public bool TryCertificateFirst
        {
            get;
            set;
        }
    }
}