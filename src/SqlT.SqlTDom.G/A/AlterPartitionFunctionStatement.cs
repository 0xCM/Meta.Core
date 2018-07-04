////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterPartitionFunctionStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public bool IsSplit
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