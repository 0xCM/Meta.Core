//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    using static ClrStructureSpec;

    public interface ICSharpSnippetGenerator : ICSharpGenerator
    {
        string GenerateClass(ClassSpec spec);

    }

    class CSharpSnippetGenerator : ApplicationService<CSharpSnippetGenerator, ICSharpSnippetGenerator>, ICSharpSnippetGenerator
    {

        public CSharpSnippetGenerator(IApplicationContext C)
            : base(C)
        {

        }

        public string GenerateClass(ClassSpec spec)
        {
            return spec.Emit();            
        }

    }

}