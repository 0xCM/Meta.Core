////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CursorId : TSqlFragment, ISqlTDomElement
    {
        public bool IsGlobal
        {
            get;
            set;
        }

        public IdentifierOrValueExpression Name
        {
            get;
            set;
        }
    }
}