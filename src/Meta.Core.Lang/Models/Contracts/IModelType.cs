//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;

    /// <summary>
    /// Associates a CLR type with an identified model type
    /// </summary>
    public interface IModelType
    {
        /// <summary>
        /// Uniquely identifies a model type within a given syntax representation
        /// </summary>
        string ModelTypeId { get; }

        /// <summary>
        /// The defining CLR type
        /// </summary>
        Type SpecifyingType { get; }

        bool IsSameAs(IModelType candiate);
    }
}