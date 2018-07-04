////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableDropTableElement : TSqlFragment, ISqlTDomElement
    {
        public TableElementType TableElementType
        {
            get;
            set;
        }

        public Identifier Name
        {
            get;
            set;
        }

        public IList<DropClusteredConstraintOption> DropClusteredConstraintOptions
        {
            get;
            set;
        }

        public bool IsIfExists
        {
            get;
            set;
        }
    }
}