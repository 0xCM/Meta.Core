//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using SqlT.Syntax;


    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Specifies the name of a SQL Server collation
    /// </summary>
    public sealed class SqlCollationName : SqlName<SqlCollationName>, ISimpleSqlName
    {
        public static implicit operator SqlCollationName(string x)
            => new SqlCollationName(x);

        public SqlCollationName()
            : this(string.Empty)
        { }


        public SqlCollationName(string Value)
            : base(Value)
        { }

        public override string ToString()
            => base.UnqualifiedName;

    }
}
