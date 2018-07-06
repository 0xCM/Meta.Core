//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;
    using SqlT.Services;

    using static metacore;

    using static ClrStructureSpec;

    class SqlFieldListGenerator : ApplicationService<SqlFieldListGenerator, ISqlFieldListGenerator>, ISqlFieldListGenerator
    {

        public SqlFieldListGenerator(IApplicationContext C)
            : base(C)
        { }

        IReadOnlyList<FilePath> EmitLists(SqlFieldListGenerationProfile gp, IEnumerable<ClassSpec> lists)
        {
            var usings = gp.SpecifyUsings();
            var nsname = gp.SpecifyNamespaceName();
            var ns = new NamespaceSpec(nsname, lists, usings);
            var filespec = gp.SpecifyCodeFile(gp.Name, ns, true);
            return gp.Emit(array(filespec));

        }

        public IReadOnlyList<FilePath> GenerateFieldLists(SqlFieldListGenerationProfile gp)
        {
            Notify(inform($"Generatating {gp.ProjectName} field lists"));

            var svp = SqlSystemViews.Create(
                new SystemViewsSettings
                (
                    gp.ConnectionString,
                    Filter: new SystemViewFilter
                    {
                        ExcludeSystemObjects = gp.ExcludeSystemObjects
                    }
                    
                ));
           
            var lists = EmitLists(gp, rolist(gp.SpecifyFieldLists(svp)));
            iter(lists, l => Notify(inform($"Emitted {l.FileName}")));
            return lists;
        }
    }
}