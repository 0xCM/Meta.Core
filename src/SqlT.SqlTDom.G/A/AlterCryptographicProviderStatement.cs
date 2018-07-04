////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterCryptographicProviderStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public EnableDisableOptionType Option
        {
            get;
            set;
        }

        public Literal File
        {
            get;
            set;
        }
    }
}