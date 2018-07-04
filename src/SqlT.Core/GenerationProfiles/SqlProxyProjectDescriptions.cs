//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;      

    public sealed class SqlProxyProjectDescriptions : ReadOnlySet<SqlProxyProjectDescription>
    {
        public static implicit operator SqlProxyProjectDescriptions(SqlProxyProjectDescription[] items)
            => new SqlProxyProjectDescriptions(items);

        
        public SqlProxyProjectDescriptions(IEnumerable<SqlProxyProjectDescription> items)
            : base(items)
        { }

        public SqlProxyProjectDescriptions(params SqlProxyProjectDescription[] items)
            : base(items)
        { }

    }
}