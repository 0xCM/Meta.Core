////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateServiceStatement : AlterCreateServiceStatementBase, ISqlTDomCreateStatement
    {
        public Identifier Owner
        {
            get;
            set;
        }
    }
}