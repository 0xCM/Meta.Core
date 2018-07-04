////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class EventDeclarationCompareFunctionParameter : BooleanExpression, ISqlTDomElement
    {
        public EventSessionObjectName Name
        {
            get;
            set;
        }

        public SourceDeclaration SourceDeclaration
        {
            get;
            set;
        }

        public ScalarExpression EventValue
        {
            get;
            set;
        }
    }
}