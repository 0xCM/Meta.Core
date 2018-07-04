//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Runtime.CompilerServices;
    using SqlT.Core;

    public class SqlModelCase<TSpec>
        where TSpec : SqlModel<TSpec>
    {
        public SqlModelCase(string CaseName, TSpec Model, SqlScript Sql)
        {
            this.CaseName = CaseName;
            this.Model = Model;
            this.Sql = Sql;
        }

        public SqlModelCase(TSpec Model, SqlScript Sql, [CallerMemberName] string CaseName = null)
        {
            this.CaseName = CaseName;
            this.Model = Model;
            this.Sql = Sql;
        }

        public string CaseName { get; set; }

        public TSpec Model { get; set; }

        public SqlScript Sql { get; set; }
    }

}
