//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{

    using System;
    using System.Collections.Generic;

    using static ClrStructureSpec;

    public interface ICSharpEnumGenerator  : ICSharpGenerator
    {
        Option<int> GenerateEnums(IEnumerable<EnumSpec> SrcSpecs, ClrNamespaceName DstNS, FilePath DstPath);

        Option<int> GenerateEnums(IEnumerable<Type> SrcTypes, ClrNamespaceName DstNS, FilePath DstPath);
    }


}
