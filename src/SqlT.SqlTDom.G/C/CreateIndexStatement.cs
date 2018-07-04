////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateIndexStatement : IndexStatement, ISqlTDomCreateStatement
    {
        public bool Translated80SyntaxTo90
        {
            get;
            set;
        }

        public bool Unique
        {
            get;
            set;
        }

        public Nullable<Boolean> Clustered
        {
            get;
            set;
        }

        public IList<ColumnWithSortOrder> Columns
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> IncludeColumns
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