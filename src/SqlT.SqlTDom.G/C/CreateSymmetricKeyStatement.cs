////This file was generated 6/24/2017 12:42:32 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateSymmetricKeyStatement : SymmetricKeyStatement, ISqlTDomCreateStatement
    {
        public IList<KeyOption> KeyOptions
        {
            get;
            set;
        }

        public Identifier Provider
        {
            get;
            set;
        }

        public Identifier Owner
        {
            get;
            set;
        }
    }
}