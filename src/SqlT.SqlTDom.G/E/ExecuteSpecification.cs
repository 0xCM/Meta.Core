////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ExecuteSpecification : TSqlFragment, ISqlTDomElement
    {
        public VariableReference Variable
        {
            get;
            set;
        }

        public Identifier LinkedServer
        {
            get;
            set;
        }

        public ExecuteContext ExecuteContext
        {
            get;
            set;
        }

        public ExecutableEntity ExecutableEntity
        {
            get;
            set;
        }
    }
}