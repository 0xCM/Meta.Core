////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ColumnDefinitionBase : TSqlFragment, ISqlTDomElement
    {
        public Identifier ColumnIdentifier
        {
            get;
            set;
        }

        public DataTypeReference DataType
        {
            get;
            set;
        }

        public Identifier Collation
        {
            get;
            set;
        }
    }
}