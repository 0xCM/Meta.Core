////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class GridParameter : TSqlFragment, ISqlTDomElement
    {
        public GridParameterType Parameter
        {
            get;
            set;
        }

        public ImportanceParameterType Value
        {
            get;
            set;
        }
    }
}