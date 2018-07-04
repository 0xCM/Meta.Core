//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using SqlT.Core;

    public class SqlScriptAnalysis
    {

        public SqlScriptAnalysis(SqlScript SrcScript)
        {
            this.SrcScript = SrcScript;
        }

        SqlScript SrcScript { get; }

        public override string ToString()
            => SrcScript.ToString();
    }





}