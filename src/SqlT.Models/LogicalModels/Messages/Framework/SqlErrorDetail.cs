//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;

    using static metacore;

    using SqlT.Core;

    public abstract class SqlErrorDetail<D>
        where D : SqlErrorDetail<D>
    {

        protected static string CreateRegexPattern(string MessageTemplate)
        {
            var script = new Script(MessageTemplate);
            var parameters = script.GetParameterNames(false);
            foreach (var parameter in parameters)
            {
                script = script.SpecifyParameter(parameter, $"(?<{parameter}>(.*))");
            }
            return script;
        }

        protected SqlErrorDetail(SqlException e)
        {
            this.Exception = e;
        }

        public SqlException Exception { get; }
    }


}