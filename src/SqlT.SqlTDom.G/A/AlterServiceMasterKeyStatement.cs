////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterServiceMasterKeyStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Literal Account
        {
            get;
            set;
        }

        public Literal Password
        {
            get;
            set;
        }

        public AlterServiceMasterKeyOption Kind
        {
            get;
            set;
        }
    }
}