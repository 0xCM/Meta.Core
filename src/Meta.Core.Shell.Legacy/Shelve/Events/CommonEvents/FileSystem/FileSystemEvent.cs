//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using static metacore;


    using N = SystemNodeIdentifier;


    public abstract class FileSystemEvent<F> : NodeEvent<F>
        where F : IFileSystemObject
    {
        protected FileSystemEvent(N EventSource, F FSO, string EventName, CorrelationToken? CT = null, bool ErrorCondition = false, DateTime? Timestamp = null)
            : base(EventSource, FSO,  EventName, CT, ErrorCondition, Timestamp)
        {


        }

    }
 

}