//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMetaApp : IShellCommandController, IShellCommandProvider
    {
         IAssemblyDesignator AppDesignator { get; }

         Type AppType { get; }
    }

    public interface IMetaApp<A> : IMetaApp
        where A : IMetaApp
    {

    }


}