////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterLoginAddDropCredentialStatement : AlterLoginStatement, ISqlTDomAlterStatement
    {
        public bool IsAdd
        {
            get;
            set;
        }

        public Identifier CredentialName
        {
            get;
            set;
        }
    }
}