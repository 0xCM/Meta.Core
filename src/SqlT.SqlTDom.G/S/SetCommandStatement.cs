////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SetCommandStatement : TSqlStatement, ISqlTDomStatement
    {
        public IList<SetCommand> Commands
        {
            get;
            set;
        }
    }
}