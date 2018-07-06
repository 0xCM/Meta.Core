//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace WF
{

    using System;
    using System.Collections.Generic;
    using System.Linq;


    using SqlT.Core;
    using SqlT.Syntax;
    using sxf = SqlT.Syntax.SqlTypes;
    using static SqlT.Bindings.TypeStructures;                                            
    using static SqlT.Syntax.SqlNativeTypeRefs;

    using static metacore;

    public sealed class TaskResultType : TableType<TaskResultType, TaskType>
    {

        public BIT Suceeded { get; }
            = sxf.bit(false);

        public NVARCHAR ResultDescription { get; }
            = sxf.nvarchar(250, false);

    }




}