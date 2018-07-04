////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OptimizeForOptimizerHint : OptimizerHint, ISqlTDomElement
    {
        public IList<VariableValuePair> Pairs
        {
            get;
            set;
        }

        public bool IsForUnknown
        {
            get;
            set;
        }
    }
}