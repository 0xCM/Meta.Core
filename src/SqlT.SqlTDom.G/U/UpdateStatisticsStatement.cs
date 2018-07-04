////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UpdateStatisticsStatement : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName SchemaObjectName
        {
            get;
            set;
        }

        public IList<Identifier> SubElements
        {
            get;
            set;
        }

        public IList<StatisticsOption> StatisticsOptions
        {
            get;
            set;
        }
    }
}