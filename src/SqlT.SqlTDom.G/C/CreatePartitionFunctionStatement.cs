////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreatePartitionFunctionStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public PartitionParameterType ParameterType
        {
            get;
            set;
        }

        public PartitionFunctionRange Range
        {
            get;
            set;
        }

        public IList<ScalarExpression> BoundaryValues
        {
            get;
            set;
        }
    }
}