//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct sysname
    {
        public static implicit operator sysname(string value)
            => new sysname(value);

        public static implicit operator string(sysname value)
            => value;

        public sysname(string value)
            => this.value = value;

        public string value { get; }

        public override string ToString()
            => value;
    }

}
