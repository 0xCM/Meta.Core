////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class NameFileDeclarationOption : FileDeclarationOption, ISqlTDomOption
    {
        public IdentifierOrValueExpression LogicalFileName
        {
            get;
            set;
        }

        public bool IsNewName
        {
            get;
            set;
        }
    }
}