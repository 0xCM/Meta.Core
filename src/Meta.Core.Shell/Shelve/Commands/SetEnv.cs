﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [CommandSpec]
    public class SetEnvironmentVariables : CommandSpec<SetEnvironmentVariables, int>
    {
        public IReadOnlyList<NamedValue> Variables { get; set; }
    }

}