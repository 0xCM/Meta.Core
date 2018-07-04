////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CursorDefinition : TSqlFragment, ISqlTDomElement
    {
        public IList<CursorOption> Options
        {
            get;
            set;
        }

        public SelectStatement Select
        {
            get;
            set;
        }
    }
}