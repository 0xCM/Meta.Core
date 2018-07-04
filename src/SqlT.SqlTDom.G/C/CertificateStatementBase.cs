////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class CertificateStatementBase : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public OptionState ActiveForBeginDialog
        {
            get;
            set;
        }

        public Literal PrivateKeyPath
        {
            get;
            set;
        }

        public Literal EncryptionPassword
        {
            get;
            set;
        }

        public Literal DecryptionPassword
        {
            get;
            set;
        }
    }
}