////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UniqueConstraintDefinition : ConstraintDefinition, ISqlTDomElement
    {
        public Nullable<Boolean> Clustered
        {
            get;
            set;
        }

        public bool IsPrimaryKey
        {
            get;
            set;
        }

        public IList<ColumnWithSortOrder> Columns
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

        public IndexType IndexType
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