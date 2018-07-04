////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ChangeTableVersionTableReference : TableReferenceWithAliasAndColumns, ISqlTDomElement
    {
        public SchemaObjectName Target
        {
            get;
            set;
        }

        public IList<Identifier> PrimaryKeyColumns
        {
            get;
            set;
        }

        public IList<ScalarExpression> PrimaryKeyValues
        {
            get;
            set;
        }
    }
}