////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ViewStatementBody : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName SchemaObjectName
        {
            get;
            set;
        }

        public IList<Identifier> Columns
        {
            get;
            set;
        }

        public IList<ViewOption> ViewOptions
        {
            get;
            set;
        }

        public SelectStatement SelectStatement
        {
            get;
            set;
        }

        public bool WithCheckOption
        {
            get;
            set;
        }
    }
}