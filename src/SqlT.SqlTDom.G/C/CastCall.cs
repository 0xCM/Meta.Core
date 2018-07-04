////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CastCall : PrimaryExpression, ISqlTDomElement
    {
        public DataTypeReference DataType
        {
            get;
            set;
        }

        public ScalarExpression Parameter
        {
            get;
            set;
        }
    }
}