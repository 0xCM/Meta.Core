////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SequenceOption : TSqlFragment, ISqlTDomOption
    {
        public SequenceOptionKind OptionKind
        {
            get;
            set;
        }

        public bool NoValue
        {
            get;
            set;
        }
    }
}