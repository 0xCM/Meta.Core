////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseAddFileGroupStatement : AlterDatabaseStatement, ISqlTDomAlterStatement
    {
        public Identifier FileGroup
        {
            get;
            set;
        }

        public bool ContainsFileStream
        {
            get;
            set;
        }

        public bool ContainsMemoryOptimizedData
        {
            get;
            set;
        }
    }
}