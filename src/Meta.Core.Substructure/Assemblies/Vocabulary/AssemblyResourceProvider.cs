//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Concurrent;

/// <summary>
/// Provides access to the embedded resources compiled into an assembly
/// </summary>
public sealed class AssemblyResourceProvider
{
    static ConcurrentDictionary<Assembly, AssemblyResourceProvider> providers 
        = new ConcurrentDictionary<Assembly, AssemblyResourceProvider>();

    public static AssemblyResourceProvider Get() 
        => Get(Assembly.GetCallingAssembly());

    public static AssemblyResourceProvider Get(Assembly assembly) 
        => providers.GetOrAdd(assembly, a => new AssemblyResourceProvider(a));

    public static string GetTextResource<T>()
        => Get(typeof(T).Assembly).FindTextResource(typeof(T).FullName);

    public static string GetTextResource<T>(string resid)
        => Get(typeof(T).Assembly).FindTextResource(resid);

    readonly Assembly assembly;
    readonly IReadOnlyList<string> resnames;

    string ReadNamedTextResource(string resname)
    {
        using (var stream = assembly.GetManifestResourceStream(resname))
        using (var reader = new StreamReader(stream))
            return reader.ReadToEnd();
    }

    public AssemblyResourceProvider(Assembly assembly)
    {
        this.assembly = assembly;
        this.resnames = assembly.GetManifestResourceNames();
    }

    public AssemblyResourceProvider(string path)
        : this(Assembly.LoadFrom(path))
    {
    }

    public string GetResourceName(string resid)
    {
        var resname = resnames.FirstOrDefault(name => name.Contains(resid));
        if (resname == null)
            throw new ArgumentException($"The resource {resid} could not be found");
        return resname;
    }

    public IReadOnlyList<string> GetResourceNames() 
        => resnames;

    public Assembly SourceAssembly 
        => assembly;

    public string FindTextResource(string resid)
    {
        var resname = GetResourceName(resid);

        using (var stream = assembly.GetManifestResourceStream(resname))
        {
            using (var r = new StreamReader(stream))
            {
                return r.ReadToEnd();
            }
        }
    }

    public Option<string> TryFindResName(string resid)
        => (from n in resnames where n.Contains(resid) select n).FirstOrDefault();

    public Option<TextResource> TryFindTextResource(string resid)
        => from n in TryFindResName(resid)
           let res = new TextResource(n, FindTextResource(resid))
           select res;

    public IEnumerable<TextResource> TextResources(string match)
    {
        var names = from n in resnames
                    where n.Contains(match)
                    select n;
        foreach (var name in names)
            yield return new TextResource(name, ReadNamedTextResource(name));

    }

    public void EmitTextResource(string resid, string path)
    {
        var resname = GetResourceName(resid);
        using (var stream = assembly.GetManifestResourceStream(resname))
        {
            using (var reader = new StreamReader(stream))
            {
                using (var writer = new StreamWriter(path))
                {
                    while (!reader.EndOfStream)
                        writer.WriteLine(reader.ReadLine());
                    writer.Flush();
                }
            }
        }
    }

    public IEnumerable<string> ReadTextLines(string resid)
    {

        using (var stream = OpenResourceStream(resid))
        {
            using (var r = new StreamReader(stream))
            {
                while(!r.EndOfStream)
                    yield return r.ReadLine();
            }
        }
    }

    public Stream OpenResourceStream(string resid) 
        =>  assembly.GetManifestResourceStream(GetResourceName(resid));

}

