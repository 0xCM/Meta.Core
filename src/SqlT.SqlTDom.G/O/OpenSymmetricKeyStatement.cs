////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OpenSymmetricKeyStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public CryptoMechanism DecryptionMechanism
        {
            get;
            set;
        }
    }
}