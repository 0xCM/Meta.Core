////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MaxSizeFileDeclarationOption : FileDeclarationOption, ISqlTDomOption
    {
        public Literal MaxSize
        {
            get;
            set;
        }

        public MemoryUnit Units
        {
            get;
            set;
        }

        public bool Unlimited
        {
            get;
            set;
        }
    }
}