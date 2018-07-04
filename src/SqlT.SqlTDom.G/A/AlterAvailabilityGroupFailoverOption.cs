////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterAvailabilityGroupFailoverOption : TSqlFragment, ISqlTDomOption
    {
        public FailoverActionOptionKind OptionKind
        {
            get;
            set;
        }

        public Literal Value
        {
            get;
            set;
        }
    }
}