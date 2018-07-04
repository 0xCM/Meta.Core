////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class SignatureStatementBase : TSqlStatement, ISqlTDomStatement
    {
        public bool IsCounter
        {
            get;
            set;
        }

        public SignableElementKind ElementKind
        {
            get;
            set;
        }

        public SchemaObjectName Element
        {
            get;
            set;
        }

        public IList<CryptoMechanism> Cryptos
        {
            get;
            set;
        }
    }
}