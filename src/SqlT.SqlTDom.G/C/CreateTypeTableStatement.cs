////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateTypeTableStatement : CreateTypeStatement, ISqlTDomCreateStatement
    {
        public TableDefinition Definition
        {
            get;
            set;
        }

        public IList<TableOption> Options
        {
            get;
            set;
        }
    }
}