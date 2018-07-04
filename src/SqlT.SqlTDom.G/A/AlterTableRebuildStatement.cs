////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableRebuildStatement : AlterTableStatement, ISqlTDomAlterStatement
    {
        public PartitionSpecifier Partition
        {
            get;
            set;
        }

        public IList<IndexOption> IndexOptions
        {
            get;
            set;
        }
    }
}