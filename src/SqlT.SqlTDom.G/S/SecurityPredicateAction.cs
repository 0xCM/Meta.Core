////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SecurityPredicateAction : TSqlFragment, ISqlTDomElement
    {
        public SecurityPredicateActionType ActionType
        {
            get;
            set;
        }

        public SecurityPredicateType SecurityPredicateType
        {
            get;
            set;
        }

        public FunctionCall FunctionCall
        {
            get;
            set;
        }

        public SchemaObjectName TargetObjectName
        {
            get;
            set;
        }

        public SecurityPredicateOperation SecurityPredicateOperation
        {
            get;
            set;
        }
    }
}