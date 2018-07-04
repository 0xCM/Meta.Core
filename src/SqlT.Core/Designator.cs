//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using SqlT.Core;
using static metacore;


[assembly: SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Annoying rule that should not fire within DSL development contexts",
    Scope = "module")]


public abstract class SqlTModule<A>: AssemblyDesignator<A>
    where A : SqlTModule<A>, new()
{

    public const string AssemblyVersion = "1.2018.06";
    public const string ProductName = "sqlt/core";

}

public sealed class SqlTCoreModule : SqlTModule<SqlTCoreModule>
{

}

public static class SqlTCore
{
    public const string AssemblyVersion = SqlTCoreModule.AssemblyVersion;
    public const string ProductName = SqlTCoreModule.ProductName;
    public const string ComponentName = nameof(SqlTCore);
    public const string CoreNamespace = "SqlT.Core";
    public const string Identifier = "SqlT.Core";
    public const string VersionMoniker = ComponentName + "Version";

    public static Assembly Assembly
        => Assembly.GetExecutingAssembly();

    static string[] resnames =
        Assembly.GetManifestResourceNames();

    public static string AssemblyPath
        => Assembly.Location;


    static Option<string> GetResourceName(string resid)
    {
        var resname = resnames.FirstOrDefault(name => name.Contains(resid));
        if (resname != null)
            return resname;
        else
            return none<string>(error($"The resource {resid} could not be found int the {Assembly} assembly"));
    }

    static Option<string> ExtractText(string resname)
    {
        try
        {
            using (var stream = Assembly.GetManifestResourceStream(resname))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        catch (Exception e)
        {
            return none<string>(e);
        }
    }

    internal static Option<string> GetTextResource(string resid)
        => from name in GetResourceName(resid)
           from text in ExtractText(name)
           select text;
}

