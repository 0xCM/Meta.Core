////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterFederationStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public AlterFederationKind Kind
        {
            get;
            set;
        }

        public Identifier DistributionName
        {
            get;
            set;
        }

        public ScalarExpression Boundary
        {
            get;
            set;
        }
    }
}