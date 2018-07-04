////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FileGrowthFileDeclarationOption : FileDeclarationOption, ISqlTDomOption
    {
        public Literal GrowthIncrement
        {
            get;
            set;
        }

        public MemoryUnit Units
        {
            get;
            set;
        }
    }
}