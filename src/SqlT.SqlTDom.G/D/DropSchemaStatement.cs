////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DropSchemaStatement : TSqlStatement, ISqlTDomDropStatement
    {
        public SchemaObjectName Schema
        {
            get;
            set;
        }

        public DropSchemaBehavior DropBehavior
        {
            get;
            set;
        }

        public bool IsIfExists
        {
            get;
            set;
        }
    }
}