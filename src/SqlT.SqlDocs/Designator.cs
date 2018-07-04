using System;
using System.Reflection;
using System.Collections.Generic;

using static metacore;




public class SqlTSqlDocs : SqlTModule<SqlTSqlDocs>
{

    public const string ServiceName = nameof(SqlTSqlDocs);

    public static ClrAssembly ClrAssembly
        => global::ClrAssembly.Get(Assembly);
    public SqlTSqlDocs()
    {
        
    }

    /// <summary>
    /// Specifies the dependencies on which the shell depends for services
    /// </summary>
    public override IReadOnlyList<Assembly> ModuleDependencies
        => stream
            (
                
                MetaCoreCommands.Assembly,
                MetaCoreJson.Assembly,
                SqlTSqlDocs.Assembly
            ).ToReadOnlyList();
}
