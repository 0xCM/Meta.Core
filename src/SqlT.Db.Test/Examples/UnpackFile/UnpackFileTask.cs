﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace DF
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;
    using sxf = SqlT.Syntax.SqlTypes;
    using static SqlT.Bindings.TypeStructures;

    public class UnpackFileTask
        : TableType<UnpackFileTask, UnpackFileCommand, WF.TaskType>
    {

    }

}