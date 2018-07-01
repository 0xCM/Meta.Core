//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;

    public class FileChangeReceiver : ApplicationService<FileChangeReceiver, IFileChangeReceiver>, IFileChangeReceiver
    {
        public FileChangeReceiver(IApplicationContext C)
            : base(C) { }



        public void Receive(FileChangeDescription FileChange)
        {
            Notify(babble(FileChange.ToString()));
        }

    }
}
