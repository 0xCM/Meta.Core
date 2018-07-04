////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UpdateTextStatement : TextModificationStatement, ISqlTDomStatement
    {
        public ScalarExpression InsertOffset
        {
            get;
            set;
        }

        public ScalarExpression DeleteLength
        {
            get;
            set;
        }

        public ColumnReferenceExpression SourceColumn
        {
            get;
            set;
        }

        public ValueExpression SourceParameter
        {
            get;
            set;
        }
    }
}