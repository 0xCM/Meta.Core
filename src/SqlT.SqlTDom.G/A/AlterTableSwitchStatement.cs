////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableSwitchStatement : AlterTableStatement, ISqlTDomAlterStatement
    {
        public ScalarExpression SourcePartitionNumber
        {
            get;
            set;
        }

        public ScalarExpression TargetPartitionNumber
        {
            get;
            set;
        }

        public SchemaObjectName TargetTable
        {
            get;
            set;
        }

        public IList<TableSwitchOption> Options
        {
            get;
            set;
        }
    }
}