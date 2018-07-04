////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UseFederationStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier FederationName
        {
            get;
            set;
        }

        public Identifier DistributionName
        {
            get;
            set;
        }

        public ScalarExpression Value
        {
            get;
            set;
        }

        public bool Filtering
        {
            get;
            set;
        }
    }
}