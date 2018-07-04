////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BackupEncryptionOption : BackupOption, ISqlTDomOption
    {
        public EncryptionAlgorithm Algorithm
        {
            get;
            set;
        }

        public CryptoMechanism Encryptor
        {
            get;
            set;
        }
    }
}