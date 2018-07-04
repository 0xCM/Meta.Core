////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DeclareTableVariableBody : TSqlFragment, ISqlTDomElement
    {
        public Identifier VariableName
        {
            get;
            set;
        }

        public bool AsDefined
        {
            get;
            set;
        }

        public TableDefinition Definition
        {
            get;
            set;
        }
    }
}