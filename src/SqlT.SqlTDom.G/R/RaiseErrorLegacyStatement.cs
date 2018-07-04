////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class RaiseErrorLegacyStatement : TSqlStatement, ISqlTDomStatement
    {
        public ScalarExpression FirstParameter
        {
            get;
            set;
        }

        public ValueExpression SecondParameter
        {
            get;
            set;
        }
    }
}