//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
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