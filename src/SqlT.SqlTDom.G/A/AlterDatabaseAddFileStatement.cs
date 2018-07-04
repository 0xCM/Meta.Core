////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseAddFileStatement : AlterDatabaseStatement, ISqlTDomAlterStatement
    {
        public IList<FileDeclaration> FileDeclarations
        {
            get;
            set;
        }

        public Identifier FileGroup
        {
            get;
            set;
        }

        public bool IsLog
        {
            get;
            set;
        }
    }
}