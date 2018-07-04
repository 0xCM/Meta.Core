////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DeclareVariableElement : TSqlFragment, ISqlTDomElement
    {
        public Identifier VariableName
        {
            get;
            set;
        }

        public DataTypeReference DataType
        {
            get;
            set;
        }

        public NullableConstraintDefinition Nullable
        {
            get;
            set;
        }

        public ScalarExpression Value
        {
            get;
            set;
        }
    }
}