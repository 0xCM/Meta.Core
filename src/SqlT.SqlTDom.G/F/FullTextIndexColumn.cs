////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FullTextIndexColumn : TSqlFragment, ISqlTDomElement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Identifier TypeColumn
        {
            get;
            set;
        }

        public IdentifierOrValueExpression LanguageTerm
        {
            get;
            set;
        }

        public bool StatisticalSemantics
        {
            get;
            set;
        }
    }
}