////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateColumnStoreIndexStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Nullable<Boolean> Clustered
        {
            get;
            set;
        }

        public SchemaObjectName OnName
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }

        public BooleanExpression FilterPredicate
        {
            get;
            set;
        }

        public IList<IndexOption> IndexOptions
        {
            get;
            set;
        }

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme
        {
            get;
            set;
        }
    }
}