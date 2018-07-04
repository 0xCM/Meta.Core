////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FetchCursorStatement : CursorStatement, ISqlTDomStatement
    {
        public FetchType FetchType
        {
            get;
            set;
        }

        public IList<VariableReference> IntoVariables
        {
            get;
            set;
        }
    }
}