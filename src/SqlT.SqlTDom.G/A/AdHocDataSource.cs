////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AdHocDataSource : TSqlFragment, ISqlTDomElement
    {
        public StringLiteral ProviderName
        {
            get;
            set;
        }

        public StringLiteral InitString
        {
            get;
            set;
        }
    }
}