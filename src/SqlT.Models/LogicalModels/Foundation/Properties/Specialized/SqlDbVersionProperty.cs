//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using SqlT.Core;


    public sealed class DbVersionProperty : SqlCustomProperty<DbVersionProperty, Version>
    {
        public DbVersionProperty(Version Version)
            : base(SqlPropertyNames.DbVersion, Version) { }

        public DbVersionProperty(string Version)
            : base(SqlPropertyNames.DbVersion, System.Version.Parse(Version))
        { }

    }
}
