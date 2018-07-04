////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateFullTextCatalogStatement : FullTextCatalogStatement, ISqlTDomCreateStatement
    {
        public Identifier FileGroup
        {
            get;
            set;
        }

        public Literal Path
        {
            get;
            set;
        }

        public bool IsDefault
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