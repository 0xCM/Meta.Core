////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AddSearchPropertyListAction : SearchPropertyListAction, ISqlTDomElement
    {
        public StringLiteral PropertyName
        {
            get;
            set;
        }

        public StringLiteral Guid
        {
            get;
            set;
        }

        public IntegerLiteral Id
        {
            get;
            set;
        }

        public StringLiteral Description
        {
            get;
            set;
        }
    }
}