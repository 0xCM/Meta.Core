//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{ 
    /// <summary>
    /// Ultimate base class for element specifications
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public abstract class ElementSpec<S> : ValueObject<S>, IClrElementSpec
        where S : ElementSpec<S>
    {

        protected ElementSpec(IClrElementName Name,CodeDocumentationSpec Documentation,
                ClrAccessKind AccessLevel, IEnumerable<AttributionSpec> Attributions = null)
        {
            this.Name = Name;
            this.Documentation = Documentation;
            this.AccessLevel = AccessLevel;
            this.Attributions = rovalues(Attributions);
        }

        /// <summary>
        /// The name of the element
        /// </summary>
        public IClrElementName Name { get; }

        /// <summary>
        /// Documentation for the element, if specified
        /// </summary>
        public Option<CodeDocumentationSpec> Documentation { get; }

        /// <summary>
        /// Attributes aplied to the element
        /// </summary>
        public IReadOnlyList<AttributionSpec> Attributions { get; }

        /// <summary>
        /// The element access/visibility level
        /// </summary>
        public ClrAccessKind AccessLevel { get; }

        IClrElementName IClrElementSpec.ElementName
            => Name;

        IReadOnlyList<AttributionSpec> IClrElementSpec.Attributions
            => Attributions;

        public override string ToString()
            => Name?.ToString() ?? String.Empty;
    }

}