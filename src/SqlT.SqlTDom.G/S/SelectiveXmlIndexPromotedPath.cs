////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SelectiveXmlIndexPromotedPath : TSqlFragment, ISqlTDomElement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public Literal Path
        {
            get;
            set;
        }

        public DataTypeReference SQLDataType
        {
            get;
            set;
        }

        public Literal XQueryDataType
        {
            get;
            set;
        }

        public IntegerLiteral MaxLength
        {
            get;
            set;
        }

        public bool IsSingleton
        {
            get;
            set;
        }
    }
}