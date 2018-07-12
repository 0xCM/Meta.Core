//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using static minicore;

    public static class AssemblyGenerator
    {
        static string sample =
@"  using System;
    namespace MyNamespace
    {
        public class Writer
        {
            public static void Write(string message)
            {
                Console.WriteLine(message);
            }
        }
    }";


        public static Assembly Generate(Script code, params FilePath[] assemblyrefs)
        {
            var syntax = CSharpSyntaxTree.ParseText(code);
            var assembly = default(Assembly);
            var metarefs = assemblyrefs.Select(path => MetadataReference.CreateFromFile(path));
            var compilation = CSharpCompilation.Create("MyAssembly", stream(syntax), metarefs, 
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
