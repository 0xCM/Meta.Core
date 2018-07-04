////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterEventSessionStatement : EventSessionStatement, ISqlTDomAlterStatement
    {
        public AlterEventSessionStatementType StatementType
        {
            get;
            set;
        }

        public IList<EventSessionObjectName> DropEventDeclarations
        {
            get;
            set;
        }

        public IList<EventSessionObjectName> DropTargetDeclarations
        {
            get;
            set;
        }
    }
}