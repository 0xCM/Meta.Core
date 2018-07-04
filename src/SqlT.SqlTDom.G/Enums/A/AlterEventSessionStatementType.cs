////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AlterEventSessionStatementType : int
    {
        Unknown = 0,
        AddEventDeclarationOptionalSessionOptions = 1,
        DropEventSpecificationOptionalSessionOptions = 2,
        AddTargetDeclarationOptionalSessionOptions = 3,
        DropTargetSpecificationOptionalSessionOptions = 4,
        RequiredSessionOptions = 5,
        AlterStateIsStart = 6,
        AlterStateIsStop = 7
    }
}