////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ParseError : ISqlTDomElement
    {
        public int Number
        {
            get;
            set;
        }

        public int Offset
        {
            get;
            set;
        }

        public int Line
        {
            get;
            set;
        }

        public int Column
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}