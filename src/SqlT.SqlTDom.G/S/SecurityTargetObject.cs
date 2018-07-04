////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SecurityTargetObject : TSqlFragment, ISqlTDomElement
    {
        public SecurityObjectKind ObjectKind
        {
            get;
            set;
        }

        public SecurityTargetObjectName ObjectName
        {
            get;
            set;
        }

        public IList<Identifier> Columns
        {
            get;
            set;
        }
    }
}