////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateFullTextStopListStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public bool IsSystemStopList
        {
            get;
            set;
        }

        public Identifier DatabaseName
        {
            get;
            set;
        }

        public Identifier SourceStopListName
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