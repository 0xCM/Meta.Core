////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DropAlterFullTextIndexAction : AlterFullTextIndexAction, ISqlTDomElement
    {
        public IList<Identifier> Columns
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