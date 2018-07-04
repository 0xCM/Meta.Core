//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Templates;

    public class SqlSystemOperations
    {
        ISqlExecutor Executor { get; }

        SqlConnectionString ConnectionString { get; }

        public SqlSystemOperations(ISqlExecutor executor, SqlConnectionString cs)
        {
            this.Executor = executor;
            this.ConnectionString = cs;
        }

        /// <summary>
        /// Determines whether an identified SQL Object eixts
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <returns></returns>
        public bool ObjectExists(SqlObjectName name)
            => Executor.Execute<SqlObjectExists.Result>(ConnectionString, new SqlObjectExists(name)).Single().ObjectExists;

        public void CreateSequence(SqlSequenceName SequenceName, SqlTypeName TypeName)
        {
            var specification = new SqlSequence(
                SequenceName: SequenceName,
                SequenceDataType: SqlNativeTypes.TryFind(TypeName).Require().Reference(false),
                InitialValue: "1",
                Increment: "1",
                CacheSize: "10"
                );

            Executor.CreateElement(ConnectionString, specification);
        }
    }
}
