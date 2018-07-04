////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterServerAuditStatement : ServerAuditStatement, ISqlTDomAlterStatement
    {
        public Identifier NewName
        {
            get;
            set;
        }

        public bool RemoveWhere
        {
            get;
            set;
        }
    }
}