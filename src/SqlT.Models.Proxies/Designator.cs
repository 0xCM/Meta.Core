//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using System;
using static metacore;
using SqlT.Core;

[assembly: AssemblyVersion(SqlTCore.AssemblyVersion)]
[assembly: SqlProxyAssembly]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Annoying rule that should not fire within DSL development contexts",
    Scope = "module")]



public class SqlTModelProxies : SqlTModule<SqlTModelProxies>
{
    public SqlTModelProxies()
    {
        SqlTTypeProxies.Assembly.RegisterSqlProxies();
    }
}

