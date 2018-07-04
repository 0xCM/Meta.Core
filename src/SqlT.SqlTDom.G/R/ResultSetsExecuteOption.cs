////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ResultSetsExecuteOption : ExecuteOption, ISqlTDomOption
    {
        public ResultSetsOptionKind ResultSetsOptionKind
        {
            get;
            set;
        }

        public IList<ResultSetDefinition> Definitions
        {
            get;
            set;
        }
    }
}