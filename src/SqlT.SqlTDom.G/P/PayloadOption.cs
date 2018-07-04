////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class PayloadOption : TSqlFragment, ISqlTDomOption
    {
        public PayloadOptionKinds Kind
        {
            get;
            set;
        }
    }
}