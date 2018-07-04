////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateFederationStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Identifier DistributionName
        {
            get;
            set;
        }

        public DataTypeReference DataType
        {
            get;
            set;
        }
    }
}