////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateTypeUddtStatement : CreateTypeStatement, ISqlTDomCreateStatement
    {
        public DataTypeReference DataType
        {
            get;
            set;
        }

        public NullableConstraintDefinition NullableConstraint
        {
            get;
            set;
        }
    }
}