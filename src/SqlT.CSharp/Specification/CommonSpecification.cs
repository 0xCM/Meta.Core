//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;

    using SqlT.Core;

    using SqlT.Models;
    using SqlT.SqlSystem;


    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;
    using static ClrBehaviorSpec;

    using Templates;
    using static GenerationMessages;

    static class SpecificationExtensions
    {

        static IReadOnlySet<string> DefaultUsings
            = roset("System", "System.Collections.Generic", "System.ComponentModel", SqlTCore.CoreNamespace);

        static string PreambleText
            => $"This file was generated at {now()} using version {SqlTCore.Assembly.GetName().Version} the SqT data access toolset.";

        public static ClassSpec SpecifyStructure(this SystemUri uri)
        {
            var last = default(ClassSpec);
            foreach (var segment in uri.Path.Components().Reverse())
            {
                if (last == null)
                    last = new ClassSpec(segment.SpecifyClrClassName());
                else
                    last = new ClassSpec(segment.SpecifyClrClassName(), DeclaredTypes: array(last));
            }
            return last;
        }

        public static CodeFilePreamble SpecifyFilePreamble(this CodeGenerationProfile gp)
            => PreambleText.SpecifyCodeFilePreamble();

        public static IEnumerable<UsingSpec> SpecifyUsings(this CodeGenerationProfile gp)
            => from n in unionize(gp.DefaultUsings, DefaultUsings)
               select n.SpecifyUsing();

        public static ClrNamespaceName SpecifyNamespaceName(this CodeGenerationProfile gp, params string[] subcomponents)
            => array(gp.RootNamespace, subcomponents).SpecifyNamespaceName();            

        public static SqlProxySchemaSelection GetSchemaSelection(this vObject subject, SqlProxyGenerationProfile gp)
            => gp.Schemas.Single(s => s.SchemaName == subject.SchemaName);

        public static IEnumerable<ClrInterfaceName> GetImplicitDataContracts(this vTable subject, SqlProxyGenerationProfile gp)
        {
            var schemaSelection = subject.GetSchemaSelection(gp);
            if (schemaSelection != null && schemaSelection.ImplicitTableContractExclusions != null)
            {
                if (!schemaSelection.ImplicitTableContractExclusions.Contains(subject.Name))
                {
                    foreach (ClrInterfaceName ifname in schemaSelection.ImplicitTableContractNames)                        
                        if (not(ifname.IsAnonymous))
                            yield return ifname;
                }
            }

        }


    }
}
