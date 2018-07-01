//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Represents a syntactic identifier
    /// </summary>
    public interface IIdentifier : IModel
    {
        /// <summary>
        /// The raw text representing the identifier
        /// </summary>
        string IdentifierText { get; }

        /// <summary>
        /// Specifies whether the identifier is equivalent to the empty identifier
        /// </summary>
        bool IsEmpty { get; }

    }


}