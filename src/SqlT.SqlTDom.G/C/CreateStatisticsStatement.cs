////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateStatisticsStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public SchemaObjectName OnName
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }

        public IList<StatisticsOption> StatisticsOptions
        {
            get;
            set;
        }

        public BooleanExpression FilterPredicate
        {
            get;
            set;
        }
    }
}