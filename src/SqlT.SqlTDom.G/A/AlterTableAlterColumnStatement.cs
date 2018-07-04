////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableAlterColumnStatement : AlterTableStatement, ISqlTDomAlterStatement
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

        public AlterTableAlterColumnOption AlterTableAlterColumnOption
        {
            get;
            set;
        }

        public ColumnStorageOptions StorageOptions
        {
            get;
            set;
        }

        public IList<IndexOption> Options
        {
            get;
            set;
        }

        public Nullable<GeneratedAlwaysType> GeneratedAlways
        {
            get;
            set;
        }

        public bool IsHidden
        {
            get;
            set;
        }

        public Identifier Collation
        {
            get;
            set;
        }

        public bool IsMasked
        {
            get;
            set;
        }

        public StringLiteral MaskingFunction
        {
            get;
            set;
        }
    }
}