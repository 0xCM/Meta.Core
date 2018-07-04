////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OpenXmlTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public ValueExpression RowPattern
        {
            get;
            set;
        }

        public ValueExpression Flags
        {
            get;
            set;
        }

        public IList<SchemaDeclarationItem> SchemaDeclarationItems
        {
            get;
            set;
        }

        public SchemaObjectName TableName
        {
            get;
            set;
        }
    }
}