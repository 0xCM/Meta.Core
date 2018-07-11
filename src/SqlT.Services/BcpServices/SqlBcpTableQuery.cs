//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using SqlT.Core;
    using SqlT.Syntax;

    

    public sealed class SqlBcpTableQuery : SqlTableQuery<SqlBcpTableQuery>
    {

        public SqlBcpTableQuery(SqlTableName srcTable, ISqlScript Script, (string name, string value) Filter)
            : base(srcTable, Script, Filter)
        {
        }


    }
}