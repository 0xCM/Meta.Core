////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class ExternalDataSourceStatement : TSqlStatement, ISqlTDomStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public ExternalDataSourceType DataSourceType
        {
            get;
            set;
        }

        public Literal Location
        {
            get;
            set;
        }

        public IList<ExternalDataSourceOption> ExternalDataSourceOptions
        {
            get;
            set;
        }
    }
}