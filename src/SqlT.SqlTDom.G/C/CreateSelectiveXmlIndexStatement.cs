////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateSelectiveXmlIndexStatement : IndexStatement, ISqlTDomCreateStatement
    {
        public bool IsSecondary
        {
            get;
            set;
        }

        public Identifier XmlColumn
        {
            get;
            set;
        }

        public IList<SelectiveXmlIndexPromotedPath> PromotedPaths
        {
            get;
            set;
        }

        public XmlNamespaces XmlNamespaces
        {
            get;
            set;
        }

        public Identifier UsingXmlIndexName
        {
            get;
            set;
        }

        public Identifier PathName
        {
            get;
            set;
        }
    }
}