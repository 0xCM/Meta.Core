////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ColumnEncryptionKeyStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<ColumnEncryptionKeyValue> ColumnEncryptionKeyValues
        {
            get;
            set;
        }
    }
}