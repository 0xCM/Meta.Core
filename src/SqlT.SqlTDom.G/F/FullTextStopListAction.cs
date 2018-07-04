////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FullTextStopListAction : TSqlFragment, ISqlTDomElement
    {
        public bool IsAdd
        {
            get;
            set;
        }

        public bool IsAll
        {
            get;
            set;
        }

        public Literal StopWord
        {
            get;
            set;
        }

        public IdentifierOrValueExpression LanguageTerm
        {
            get;
            set;
        }
    }
}