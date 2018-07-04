////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FileGroupDefinition : TSqlFragment, ISqlTDomElement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public IList<FileDeclaration> FileDeclarations
        {
            get;
            set;
        }

        public bool IsDefault
        {
            get;
            set;
        }

        public bool ContainsFileStream
        {
            get;
            set;
        }

        public bool ContainsMemoryOptimizedData
        {
            get;
            set;
        }
    }
}