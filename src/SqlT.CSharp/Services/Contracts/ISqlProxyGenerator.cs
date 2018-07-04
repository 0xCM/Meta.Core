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

    using SqlT.Core;

    public interface ISqlProxyGenerator : ICSharpGenerator
    {
        IReadOnlyList<FilePath> GenerateProxies(SqlProxyGenerationProfile gp);
        IReadOnlyList<FilePath> GenerateProxies(FilePath profilePath);
        IReadOnlyList<FilePath> GenerateFieldLists(SqlFieldListGenerationProfile gp);


    }


}
