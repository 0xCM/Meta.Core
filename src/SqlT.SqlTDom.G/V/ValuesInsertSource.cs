////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ValuesInsertSource : InsertSource, ISqlTDomElement
    {
        public bool IsDefaultValues
        {
            get;
            set;
        }

        public IList<RowValue> RowValues
        {
            get;
            set;
        }
    }
}