////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SchemaDeclarationItem : TSqlFragment, ISqlTDomElement
    {
        public ColumnDefinitionBase ColumnDefinition
        {
            get;
            set;
        }

        public ValueExpression Mapping
        {
            get;
            set;
        }
    }
}