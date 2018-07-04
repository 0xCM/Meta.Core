////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MaxDispatchLatencySessionOption : SessionOption, ISqlTDomOption
    {
        public bool IsInfinite
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