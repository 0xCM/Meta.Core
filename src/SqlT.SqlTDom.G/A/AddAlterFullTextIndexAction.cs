////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AddAlterFullTextIndexAction : AlterFullTextIndexAction, ISqlTDomElement
    {
        public IList<FullTextIndexColumn> Columns
        {
            get;
            set;
        }

        public bool WithNoPopulation
        {
            get;
            set;
        }
    }
}