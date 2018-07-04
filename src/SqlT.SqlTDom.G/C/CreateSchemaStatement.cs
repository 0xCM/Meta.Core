////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateSchemaStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public StatementList StatementList
        {
            get;
            set;
        }

        public Identifier Owner
        {
            get;
            set;
        }
    }
}