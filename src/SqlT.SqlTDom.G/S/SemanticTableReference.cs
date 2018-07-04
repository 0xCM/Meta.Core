////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SemanticTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public SemanticFunctionType SemanticFunctionType
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

        public ScalarExpression SourceKey
        {
            get;
            set;
        }

        public ColumnReferenceExpression MatchedColumn
        {
            get;
            set;
        }

        public ScalarExpression MatchedKey
        {
            get;
            set;
        }
    }
}