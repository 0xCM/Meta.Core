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

    class CSharpEnumGenerator : ApplicationService<CSharpEnumGenerator, ICSharpEnumGenerator>, ICSharpEnumGenerator
    {
        public CSharpEnumGenerator(IApplicationContext C)
            : base(C)
        { }

        public Option<int> GenerateEnums(IEnumerable<EnumSpec> SrcSpecs, ClrNamespaceName DstNS, FilePath DstPath)
            => new CodeFileSpec(DstPath, new NamespaceSpec(DstNS, array(SrcSpecs))).Emit();
       
        public Option<int> GenerateEnums(IEnumerable<Type> SrcTypes, ClrNamespaceName DstNS, FilePath DstPath)
            => GenerateEnums(SrcTypes.Select(t => ClrEnum.Get(t).SpecifyStructure()), DstNS, DstPath);
    }
}
