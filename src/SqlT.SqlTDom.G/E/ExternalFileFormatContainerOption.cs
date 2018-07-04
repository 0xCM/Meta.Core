////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExternalFileFormatContainerOption : ExternalFileFormatOption, ISqlTDomOption
    {
        public IList<ExternalFileFormatOption> Suboptions
        {
            get;
            set;
        }
    }
}