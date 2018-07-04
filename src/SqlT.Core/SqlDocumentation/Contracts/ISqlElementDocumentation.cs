//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;

    using Meta.Core;

    /// <summary>
    /// Defines structural element documentation contract
    /// </summary>
    public interface ISqlElementDocumentation : IFacetTarget
    {
        /// <summary>
        /// Specifies whether the purported documented object is actaully documented
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// The name of the database element
        /// </summary>
        SqlName Name { get; }

        /// <summary>
        /// A non-technical/user-friendly name
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// A brief explanation of purpose/usage
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// A programmatic identifier that distinguishes the element within some context from its peers
        /// </summary>
        string Identifier { get; set; }


    }

    public interface ISqlElementDocumentation<N> : ISqlElementDocumentation
        where N : SqlName<N>, new()
    {
        new N Name { get; set; }
    }


}