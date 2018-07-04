////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class StopRestoreOption : RestoreOption, ISqlTDomOption
    {
        public ValueExpression Mark
        {
            get;
            set;
        }

        public ValueExpression After
        {
            get;
            set;
        }

        public bool IsStopAt
        {
            get;
            set;
        }
    }
}