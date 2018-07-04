////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FileEncryptionSource : EncryptionSource, ISqlTDomElement
    {
        public bool IsExecutable
        {
            get;
            set;
        }

        public Literal File
        {
            get;
            set;
        }
    }
}