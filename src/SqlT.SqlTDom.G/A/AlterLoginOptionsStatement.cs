////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterLoginOptionsStatement : AlterLoginStatement, ISqlTDomAlterStatement
    {
        public IList<PrincipalOption> Options
        {
            get;
            set;
        }
    }
}