//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System;

    public interface INodeCatalogSubject
    {
        INodeCatalogSubject Parent { get; }

        string Name { get; }

        string SymbolicHost { get; }

        bool IsRoot { get; }

        string RelativeLocation { get; }

        Uri ToLocalUri(FileName file = null);

        SystemResourceUrn Urn { get; }
                   
    }

}
