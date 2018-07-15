//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Represents the CSharp type system
    /// </summary>
    public sealed class CSharpSpace : TypeSpace<CSharpSpace>
    {

        public CSharpSpace()
            : this("CS")
        {

        }
        public CSharpSpace(string InstanceName)
            : base(InstanceName)
        {

        }
    }


}