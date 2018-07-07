//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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