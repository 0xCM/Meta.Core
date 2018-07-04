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
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        /// <summary>
        /// Creates a reference to a <see cref="SqlTableType"/>
        /// </summary>
        /// <param name="source">The table type for which a reference will be created</param>
        /// <returns></returns>
        public static TSql.UserDataTypeReference TSqlReference(this SqlTableType source, bool quoted = true)
            => new TSql.UserDataTypeReference
            {
                Name = source.ObjectName.TSqlSchemaObjectName(quoted)
            };

    }
}