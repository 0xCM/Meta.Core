////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateAsymmetricKeyStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public EncryptionSource KeySource
        {
            get;
            set;
        }

        public EncryptionAlgorithm EncryptionAlgorithm
        {
            get;
            set;
        }

        public Literal Password
        {
            get;
            set;
        }

        public Identifier Owner
        {
            get;
            set;
        }
    }
}