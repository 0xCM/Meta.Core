////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class MethodSpecifier : TSqlFragment, ISqlTDomElement
    {
        public Identifier AssemblyName
        {
            get;
            set;
        }

        public Identifier ClassName
        {
            get;
            set;
        }

        public Identifier MethodName
        {
            get;
            set;
        }
    }
}