//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public class ShellCommandLibrary
    {

        public static ShellCommandLibrary Create(IEnumerable<Assembly> Sources)
            => new ShellCommandLibrary(Sources);

        IReadOnlyDictionary<Type, ReadOnlySet<ShellCommandDescriptor>> CommandIndex { get; }


        public ShellCommandLibrary(IEnumerable<Assembly> Sources)
        {
            CommandIndex = dict(from source in Sources
                                from host in ShellCommand.DiscoverHosts(source)
                                let commands = ShellCommand.DiscoverCommands(host).ToReadOnlySet()
                                select (host, commands));                    
        }

        public IEnumerable<ShellCommandDescriptor> Commands(bool DeclaredOnly)
            => DeclaredOnly 
            ? CommandIndex.Values.SelectMany(x => x).Where(x => x.DefiningMethod.DeclaringType == x.HostType) 
            :  CommandIndex.Values.SelectMany(x => x);


    }


}