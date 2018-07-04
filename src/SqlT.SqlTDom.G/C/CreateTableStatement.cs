////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateTableStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public SchemaObjectName SchemaObjectName
        {
            get;
            set;
        }

        public bool AsFileTable
        {
            get;
            set;
        }

        public TableDefinition Definition
        {
            get;
            set;
        }

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme
        {
            get;
            set;
        }

        public FederationScheme FederationScheme
        {
            get;
            set;
        }

        public IdentifierOrValueExpression TextImageOn
        {
            get;
            set;
        }

        public IList<TableOption> Options
        {
            get;
            set;
        }

        public IdentifierOrValueExpression FileStreamOn
        {
            get;
            set;
        }
    }
}