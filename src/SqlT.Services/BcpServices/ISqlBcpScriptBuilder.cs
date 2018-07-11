//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Collections.Generic;

    using Meta.Core;
    using Meta.Core.Resources;

    using SqlT.Core;    

    using static metacore;

    public interface ISqlBcpScriptBuilder : IApplicationComponent
    {
        Option<SqlBcpArtifactSet> DefineBcpCommands(SqlTableName srcTable, SqlTableName dstTable);
        Option<SqlBcpArtifactSet> DefineBcpCommands(Link<SystemNode> path, SqlTableName srcTable, SqlTableName dstTable);
    }



}