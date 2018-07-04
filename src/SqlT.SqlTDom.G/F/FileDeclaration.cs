////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FileDeclaration : TSqlFragment, ISqlTDomElement
    {
        public IList<FileDeclarationOption> Options
        {
            get;
            set;
        }

        public bool IsPrimary
        {
            get;
            set;
        }
    }
}