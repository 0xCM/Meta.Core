////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateFullTextIndexStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public SchemaObjectName OnName
        {
            get;
            set;
        }

        public IList<FullTextIndexColumn> FullTextIndexColumns
        {
            get;
            set;
        }

        public Identifier KeyIndexName
        {
            get;
            set;
        }

        public FullTextCatalogAndFileGroup CatalogAndFileGroup
        {
            get;
            set;
        }

        public IList<FullTextIndexOption> Options
        {
            get;
            set;
        }
    }
}