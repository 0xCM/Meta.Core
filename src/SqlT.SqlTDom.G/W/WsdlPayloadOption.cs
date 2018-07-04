////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WsdlPayloadOption : PayloadOption, ISqlTDomOption
    {
        public bool IsNone
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