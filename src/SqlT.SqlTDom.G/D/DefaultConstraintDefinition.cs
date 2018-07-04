////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DefaultConstraintDefinition : ConstraintDefinition, ISqlTDomElement
    {
        public ScalarExpression Expression
        {
            get;
            set;
        }

        public bool WithValues
        {
            get;
            set;
        }

        public Identifier Column
        {
            get;
            set;
        }
    }
}