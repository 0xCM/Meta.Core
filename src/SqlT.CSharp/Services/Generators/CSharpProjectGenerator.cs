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
    using static metacore;

    using static ClrStructureSpec;

    using Meta.Core.Project;

    class SqlModelServices : ApplicationService<SqlModelServices, ICSharpProjectGenerator>, ICSharpProjectGenerator
    {
        public SqlModelServices(IApplicationContext C)
            : base(C)
        { }

        public Option<FilePath> GenerateProject(CSharpProject project, ProjectEmissionOptions options)
        {
            try
            {
                return C.CSharpProxyGenerator().GenerateProxies(new SqlProxyGenerationProfile
                {
                    OutputDirectory = options.ProjectRootLocation
                }).TryGetFirst();
            }
            catch(Exception e)
            {
                return none<FilePath>(e);
            }

        }
    }
}
