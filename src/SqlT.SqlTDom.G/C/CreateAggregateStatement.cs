////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateAggregateStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public AssemblyName AssemblyName
        {
            get;
            set;
        }

        public IList<ProcedureParameter> Parameters
        {
            get;
            set;
        }

        public DataTypeReference ReturnType
        {
            get;
            set;
        }
    }
}