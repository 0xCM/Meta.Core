////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TableDefinition : TSqlFragment, ISqlTDomElement
    {
        public IList<ColumnDefinition> ColumnDefinitions
        {
            get;
            set;
        }

        public IList<ConstraintDefinition> TableConstraints
        {
            get;
            set;
        }

        public IList<IndexDefinition> Indexes
        {
            get;
            set;
        }

        public SystemTimePeriodDefinition SystemTimePeriod
        {
            get;
            set;
        }
    }
}