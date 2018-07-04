////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CompressionPartitionRange : TSqlFragment, ISqlTDomElement
    {
        public ScalarExpression From
        {
            get;
            set;
        }

        public ScalarExpression To
        {
            get;
            set;
        }
    }
}