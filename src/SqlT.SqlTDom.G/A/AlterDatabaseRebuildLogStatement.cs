////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterDatabaseRebuildLogStatement : AlterDatabaseStatement, ISqlTDomAlterStatement
    {
        public FileDeclaration FileDeclaration
        {
            get;
            set;
        }
    }
}