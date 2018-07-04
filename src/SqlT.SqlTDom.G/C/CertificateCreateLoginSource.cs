////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CertificateCreateLoginSource : CreateLoginSource, ISqlTDomElement
    {
        public Identifier Certificate
        {
            get;
            set;
        }

        public Identifier Credential
        {
            get;
            set;
        }
    }
}