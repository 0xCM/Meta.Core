//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using N = SystemNode;

    public interface INodeFileSystem
    {
        T Nav<T>(N Host, params object[] args)
            where T : class, IFileSystemNavigator;

    }





}