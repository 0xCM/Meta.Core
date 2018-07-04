////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateXmlIndexStatement : IndexStatement, ISqlTDomCreateStatement
    {
        public bool Primary
        {
            get;
            set;
        }

        public Identifier XmlColumn
        {
            get;
            set;
        }

        public Identifier SecondaryXmlIndexName
        {
            get;
            set;
        }

        public SecondaryXmlIndexType SecondaryXmlIndexType
        {
            get;
            set;
        }
    }
}