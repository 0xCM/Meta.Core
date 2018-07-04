//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SqlT.Core;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public class ParsedSqlFragment
    {
        public static ParsedSqlFragment Parsed(ISqlScript SqlScript, TSql.TSqlFragment SqlFragment)
            => new ParsedSqlFragment(SqlScript, SqlFragment);

        public ParsedSqlFragment(ISqlScript SqlScript, TSql.TSqlFragment SqlFragment)
        {
            this.SqlScript = SqlScript;
            this.SqlFragment = SqlFragment;
        }
    
        public ISqlScript SqlScript { get; }

        public TSql.TSqlFragment SqlFragment { get; }

        public override string ToString()
            => SqlScript.ScriptText;
    }



}