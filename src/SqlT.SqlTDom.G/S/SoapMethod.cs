////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SoapMethod : PayloadOption, ISqlTDomElement
    {
        public Literal Alias
        {
            get;
            set;
        }

        public Literal Namespace
        {
            get;
            set;
        }

        public SoapMethodAction Action
        {
            get;
            set;
        }

        public Literal Name
        {
            get;
            set;
        }

        public SoapMethodFormat Format
        {
            get;
            set;
        }

        public SoapMethodSchemas Schema
        {
            get;
            set;
        }
    }
}