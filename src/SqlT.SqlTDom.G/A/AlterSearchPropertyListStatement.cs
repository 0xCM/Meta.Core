////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterSearchPropertyListStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public SearchPropertyListAction Action
        {
            get;
            set;
        }
    }
}