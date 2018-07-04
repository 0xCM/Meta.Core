////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class AuditSpecificationStatement : TSqlStatement, ISqlTDomStatement
    {
        public OptionState AuditState
        {
            get;
            set;
        }

        public IList<AuditSpecificationPart> Parts
        {
            get;
            set;
        }

        public Identifier SpecificationName
        {
            get;
            set;
        }

        public Identifier AuditName
        {
            get;
            set;
        }
    }
}