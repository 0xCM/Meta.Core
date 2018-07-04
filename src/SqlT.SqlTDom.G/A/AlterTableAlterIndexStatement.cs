////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableAlterIndexStatement : AlterTableStatement, ISqlTDomAlterStatement
    {
        public Identifier IndexIdentifier
        {
            get;
            set;
        }

        public AlterIndexType AlterIndexType
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