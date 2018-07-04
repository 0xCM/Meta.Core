////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateSearchPropertyListStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public MultiPartIdentifier SourceSearchPropertyList
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