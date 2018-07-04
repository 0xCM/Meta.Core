////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BulkOpenRowset : TableReferenceWithAliasAndColumns, ISqlTDomElement
    {
        public StringLiteral DataFile
        {
            get;
            set;
        }

        public IList<BulkInsertOption> Options
        {
            get;
            set;
        }
    }
}