//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using sxc = Syntax.contracts;

    using SqlT.Core;
    using SqlT.Syntax;

    /// <summary>
    /// Encapsulates a set of database options
    /// </summary>
    [SqlElementType(SqlElementTypeNames.DatabaseOptions)]
    public sealed class SqlDatabaseOptions : SqlElement<SqlDatabaseOptions>
    {
        public readonly IReadOnlyList<sxc.dboption> Selections;

        public SqlDatabaseOptions(params sxc.dboption[] selections)
            : base(SqlDatabaseOptionName.Empty, Documentation:null)
        {
            Selections = selections.ToList();
        }

        public T GetOption<T>(T defaultValue) where T : class, sxc.dboption
            => Selections.OfType<T>().SingleOrDefault() ?? defaultValue;
    }

}
