////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterAsymmetricKeyStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Literal AttestedBy
        {
            get;
            set;
        }

        public AlterCertificateStatementKind Kind
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