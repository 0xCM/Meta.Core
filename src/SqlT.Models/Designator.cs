using System.Collections.Generic;
using static metacore;

using System.Reflection;
using System;

public class SqlTModels : SqlTModule<SqlTModels>
{

    public static readonly Assembly ModelProxyAssembly 
        = typeof(SqlTModelProxies).Assembly;

}

