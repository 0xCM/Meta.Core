////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FullTextCatalogAndFileGroup : TSqlFragment, ISqlTDomElement
    {
        public Identifier CatalogName
        {
            get;
            set;
        }

        public Identifier FileGroupName
        {
            get;
            set;
        }

        public bool FileGroupIsFirst
        {
            get;
            set;
        }
    }
}