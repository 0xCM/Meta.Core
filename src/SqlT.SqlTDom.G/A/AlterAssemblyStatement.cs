////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterAssemblyStatement : AssemblyStatement, ISqlTDomAlterStatement
    {
        public IList<Literal> DropFiles
        {
            get;
            set;
        }

        public bool IsDropAll
        {
            get;
            set;
        }

        public IList<AddFileSpec> AddFiles
        {
            get;
            set;
        }
    }
}