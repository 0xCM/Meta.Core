////This file was generated 6/24/2017 12:42:36 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class TSqlFragment : ISqlTDomElement
    {
        public int StartOffset
        {
            get;
            set;
        }

        public int FragmentLength
        {
            get;
            set;
        }

        public int StartLine
        {
            get;
            set;
        }

        public int StartColumn
        {
            get;
            set;
        }

        public int FirstTokenIndex
        {
            get;
            set;
        }

        public int LastTokenIndex
        {
            get;
            set;
        }

        public IList<TSqlParserToken> ScriptTokenStream
        {
            get;
            set;
        }
    }
}