//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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