////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class InsertSpecification : DataModificationSpecification, ISqlTDomElement
    {
        public InsertOption InsertOption
        {
            get;
            set;
        }

        public InsertSource InsertSource
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }
    }
}