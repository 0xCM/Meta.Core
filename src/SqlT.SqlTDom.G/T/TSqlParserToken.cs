////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class TSqlParserToken : ISqlTDomElement
    {
        public TSqlTokenType TokenType
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

        public string Text
        {
            get;
            set;
        }
    }
}