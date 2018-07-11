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

    using static metacore;

    public sealed class DbClassifierProperty<K> : SqlCustomProperty<DbClassifierProperty<K>, K>
        where K : Enum
    {

        public DbClassifierProperty(string DatabaseType)
            : base(DatabaseType, parseEnum<K>(DatabaseType))
        { }

        public DbClassifierProperty(K DbKind)
            : base(SqlPropertyNames.DbType, DbKind) { }

    }
}
