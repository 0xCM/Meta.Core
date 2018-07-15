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


    public sealed class FileCreated : FileSystemEvent<NodeFilePath>
    {

        public FileCreated(NodeFilePath File, N EventSource, CorrelationToken? CT = null, DateTime? Timestamp = null)
            : base(EventSource, File, CT, nameof(FileCreated), false, Timestamp)
        {


        }
    }



}