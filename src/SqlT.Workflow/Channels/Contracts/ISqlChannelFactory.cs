//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using N = SystemNode;


    public interface ISqlChannelFactory
    {
        ISqlClientChannel ClientChannl();
        ISqlContext SourceContext { get; }
        ISqlContext TargetContext { get; }
    }




}