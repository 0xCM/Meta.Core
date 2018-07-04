////This file was generated 6/24/2017 12:42:34 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SchemaObjectName : MultiPartIdentifier, ISqlTDomElement
    {
        public Identifier ServerIdentifier
        {
            get;
            set;
        }

        public Identifier DatabaseIdentifier
        {
            get;
            set;
        }

        public Identifier SchemaIdentifier
        {
            get;
            set;
        }

        public Identifier BaseIdentifier
        {
            get;
            set;
        }
    }
}