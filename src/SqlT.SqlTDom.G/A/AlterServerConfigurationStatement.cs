////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterServerConfigurationStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public ProcessAffinityType ProcessAffinity
        {
            get;
            set;
        }

        public IList<ProcessAffinityRange> ProcessAffinityRanges
        {
            get;
            set;
        }
    }
}