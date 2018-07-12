//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    using SqlT.Core;
    using SqlT.Models;

    static class SqlChannelMessages
    {

        public static IAppMessage SavedRowsToTarget<T>(this ILinkedContext C, long Count)
            where T : class, ISqlTabularProxy, new()                    
            => babble($"Saved {Count} rows from {C.SourceNode} to {PXM.TabularName<T>()} on {C.TargetNode}");
                       
    }    
} 