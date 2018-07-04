////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterIndexStatement : IndexStatement, ISqlTDomAlterStatement
    {
        public bool All
        {
            get;
            set;
        }

        public AlterIndexType AlterIndexType
        {
            get;
            set;
        }

        public PartitionSpecifier Partition
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
    }
}