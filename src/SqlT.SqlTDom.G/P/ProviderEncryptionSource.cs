////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ProviderEncryptionSource : EncryptionSource, ISqlTDomElement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<KeyOption> KeyOptions
        {
            get;
            set;
        }
    }
}