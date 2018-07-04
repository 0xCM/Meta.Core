//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Topmost contract to which all nodes that either send or receive data must conform
    /// </summary>
    public interface IDataJunction
    {
        DataJunctionName Name { get; }

        Type NodeType { get; }

    }


}
