////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MoveRestoreOption : RestoreOption, ISqlTDomOption
    {
        public ValueExpression LogicalFileName
        {
            get;
            set;
        }

        public ValueExpression OSFileName
        {
            get;
            set;
        }
    }
}