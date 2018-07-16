//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;


    public static class AssemblyGen
    {
        public static Assembly Generate(string code, params string[] assemblyrefs)
        {
            var tree = new SyntaxTree[] { CSharpSyntaxTree.ParseText(code) };
            var assembly = default(Assembly);
            var metarefs = assemblyrefs.Select(path => MetadataReference.CreateFromFile(path));
            var compilation = CSharpCompilation.Create("MyAssembly", tree, metarefs, 
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var stream = new MemoryStream())
            {
                var result = compilation.Emit(stream);
                if (!result.Success)
                {
                    var failures = result.Diagnostics.Where(d => d.IsWarningAsError || d.Severity == DiagnosticSeverity.Error);
                    foreach (var fail in failures)
                        Console.WriteLine(fail.GetMessage());
                }
                else
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    assembly = Assembly.Load(stream.ToArray());
                    var t = assembly.GetType("MyNamespace.Writer");
                    var m = t.GetMethod("Write");
                    m.Invoke(null, new object[] { "Hello world" });
                    return assembly;
                }
            }
            return assembly;
        }
    }
}
