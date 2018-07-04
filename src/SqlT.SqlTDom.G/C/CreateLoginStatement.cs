////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateLoginStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public CreateLoginSource Source
        {
            get;
            set;
        }
    }
}