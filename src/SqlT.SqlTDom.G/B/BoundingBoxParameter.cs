////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class BoundingBoxParameter : TSqlFragment, ISqlTDomElement
    {
        public BoundingBoxParameterType Parameter
        {
            get;
            set;
        }

        public ScalarExpression Value
        {
            get;
            set;
        }
    }
}