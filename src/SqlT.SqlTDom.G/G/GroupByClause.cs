////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class GroupByClause : TSqlFragment, ISqlTDomElement
    {
        public GroupByOption GroupByOption
        {
            get;
            set;
        }

        public bool All
        {
            get;
            set;
        }

        public IList<GroupingSpecification> GroupingSpecifications
        {
            get;
            set;
        }
    }
}