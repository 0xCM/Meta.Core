////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class EventDeclaration : TSqlFragment, ISqlTDomElement
    {
        public EventSessionObjectName ObjectName
        {
            get;
            set;
        }

        public IList<EventDeclarationSetParameter> EventDeclarationSetParameters
        {
            get;
            set;
        }

        public IList<EventSessionObjectName> EventDeclarationActionParameters
        {
            get;
            set;
        }

        public BooleanExpression EventDeclarationPredicateParameter
        {
            get;
            set;
        }
    }
}