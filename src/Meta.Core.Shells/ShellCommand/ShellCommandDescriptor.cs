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

    using static metacore;


    public class ShellCommandDescriptor
    {
        public ShellCommandDescriptor(Type HostType, ClrMethod DefiningMethod, IEnumerable<CommandName> LocalSynonyms, string Description = null)
        {
            this.HostType = HostType;
            this.DefiningMethod = DefiningMethod;
            this.LocalName = DefiningMethod.Name;
            this.LocalSynonyms = LocalSynonyms.ToReadOnlyList();
            this.Identifier = HostType.Uri().WithNewScheme("clr.method").WithAppendedPathComponts(DefiningMethod.Name);
            this.Description = Description ?? string.Empty;
        }

        public Type HostType { get; }
         
        public ClrMethod DefiningMethod { get; }

        public IReadOnlyList<CommandName> LocalSynonyms { get; }

        public string Description { get; }

        public CommandName LocalName { get; }

        public SystemUri Identifier { get; }

        public bool IsDeclaredByHost
            => DefiningMethod.DeclaringType == HostType;

        public override string ToString()
            => concat(LocalName.Identifier.PadRight(20), HostType.Name.PadRight(15), colon(), space(), Description);
    }
}
