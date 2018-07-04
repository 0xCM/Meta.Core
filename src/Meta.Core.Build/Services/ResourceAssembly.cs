using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Reflection.Emit;

#if FULL
using Meta.Core;
/// <summary>
/// Defines operations for manipulating dynamic assemblies
/// </summary>
public static class ResourceAssembly
{

    /// <summary>
    /// Embeds data from a set of text files into a dynamic assembly and saves the result
    /// </summary>
    /// <param name="simpleAssemblyName">The name of the created assembly</param>
    /// <param name="files">The files specifying the content to embed</param>
    /// <param name="outpath">The assembly destination path</param>
    /// <returns></returns>
    public static Assembly Build(string simpleAssemblyName, IEnumerable<FilePath> files, FilePath outpath)
    {
        var asmName = new AssemblyName
        {
            Name = simpleAssemblyName,
            CodeBase = outpath,
            CultureInfo = CultureInfo.InvariantCulture,
            Version = new Version("1.0.0")
        };

        
        var assembly = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
        var asmFileName = FileName.Define(simpleAssemblyName, CommonFileExtensions.Dll);
        var module = assembly.DefineDynamicModule(asmFileName, asmFileName);
        var writer = module.DefineResource(simpleAssemblyName + ".resources", $"Embedded text file content", ResourceAttributes.Public);
        foreach (var file in files)
        {
            var resname = simpleAssemblyName + "." + file.FileName;
            writer.AddResource(resname, System.IO.File.ReadAllText(file));
        }
        assembly.Save(asmFileName);

        return assembly;
    }

}

#endif