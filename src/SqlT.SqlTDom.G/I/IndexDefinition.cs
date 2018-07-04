////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class IndexDefinition : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public bool Unique
        {
            get;
            set;
        }

        public IndexType IndexType
        {
            get;
            set;
        }

        public IList<IndexOption> IndexOptions
        {
            get;
            set;
        }

        public IList<ColumnWithSortOrder> Columns
        {
            get;
            set;
        }

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme
        {
            get;
            set;
        }

        public BooleanExpression FilterPredicate
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