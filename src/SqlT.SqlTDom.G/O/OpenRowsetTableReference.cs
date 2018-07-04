////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OpenRowsetTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public StringLiteral ProviderName
        {
            get;
            set;
        }

        public StringLiteral DataSource
        {
            get;
            set;
        }

        public StringLiteral UserId
        {
            get;
            set;
        }

        public StringLiteral Password
        {
            get;
            set;
        }

        public StringLiteral ProviderString
        {
            get;
            set;
        }

        public StringLiteral Query
        {
            get;
            set;
        }

        public SchemaObjectName Object
        {
            get;
            set;
        }
    }
}