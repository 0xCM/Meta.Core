////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FullTextTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public FullTextFunctionType FullTextFunctionType
        {
            get;
            set;
        }

        public SchemaObjectName TableName
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }

        public ValueExpression SearchCondition
        {
            get;
            set;
        }

        public ValueExpression TopN
        {
            get;
            set;
        }

        public ValueExpression Language
        {
            get;
            set;
        }

        public StringLiteral PropertyName
        {
            get;
            set;
        }
    }
}