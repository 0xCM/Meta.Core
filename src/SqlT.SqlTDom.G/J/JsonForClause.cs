////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class JsonForClause : ForClause, ISqlTDomElement
    {
        public IList<JsonForClauseOption> Options
        {
            get;
            set;
        }
    }
}