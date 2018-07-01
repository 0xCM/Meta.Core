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

    using static metacore;

    using N = SystemNode;

    public abstract class NodeFileSystem<NFS> : ApplicationService<NFS, INodeFileSystem>, INodeFileSystem
        where NFS : NodeFileSystem<NFS>

    {

        public NodeFileSystem(IApplicationContext C)
            : base(C)
        {

        }

        public T Nav<T>(N Host, params object[] args)
            where T : class, IFileSystemNavigator
        {

            var allArgs = array<object>(C, Host).Append(args);
            return cast<T>(Activator.CreateInstance(typeof(T),allArgs));
        }

    }


    [ApplicationService(nameof(MinimalNodeFileSystem))]
    class MinimalNodeFileSystem : NodeFileSystem<MinimalNodeFileSystem>
    {

        public MinimalNodeFileSystem(IApplicationContext C)
            : base(C)
        {

        }


    }
}