//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using N = SystemNodeIdentifier;




    public interface INodeMessage : ICorrelated
    {
       N Source { get; }

        N Target { get; }

        object Content { get; }
    }

    public interface INodeMessage<out M> : INodeMessage
    {
        new M Content { get; }
    }

}