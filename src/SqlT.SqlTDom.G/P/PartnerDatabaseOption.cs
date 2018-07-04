////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class PartnerDatabaseOption : DatabaseOption, ISqlTDomOption
    {
        public Literal PartnerServer
        {
            get;
            set;
        }

        public PartnerDatabaseOptionKind PartnerOption
        {
            get;
            set;
        }

        public Literal Timeout
        {
            get;
            set;
        }
    }
}