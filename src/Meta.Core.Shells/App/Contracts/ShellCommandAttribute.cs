//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    using Meta.Core.Shell;
    using static metacore;

    [AttributeUsage(AttributeTargets.Method)]
    public class ShellCommandAttribute : Attribute
    {
        public ShellCommandAttribute(params string[] Synonyms)
        {
            this.Synonyms = map(Synonyms, s => new CommandName(s));
        }

        public IReadOnlyList<CommandName> Synonyms { get; }

        public override string ToString()
            => string.Join(",", Synonyms);
    }
}