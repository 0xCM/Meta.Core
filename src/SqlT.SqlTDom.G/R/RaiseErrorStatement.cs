////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class RaiseErrorStatement : TSqlStatement, ISqlTDomStatement
    {
        public ScalarExpression FirstParameter
        {
            get;
            set;
        }

        public ScalarExpression SecondParameter
        {
            get;
            set;
        }

        public ScalarExpression ThirdParameter
        {
            get;
            set;
        }

        public IList<ScalarExpression> OptionalParameters
        {
            get;
            set;
        }

        public RaiseErrorOptions RaiseErrorOptions
        {
            get;
            set;
        }
    }
}