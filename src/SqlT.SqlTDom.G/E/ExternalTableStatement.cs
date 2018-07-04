////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ExternalTableStatement : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName SchemaObjectName
        {
            get;
            set;
        }

        public IList<ExternalTableColumnDefinition> ColumnDefinitions
        {
            get;
            set;
        }

        public Identifier DataSource
        {
            get;
            set;
        }

        public IList<ExternalTableOption> ExternalTableOptions
        {
            get;
            set;
        }
    }
}