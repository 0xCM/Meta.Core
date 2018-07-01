//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static ClrStructureSpec;

/// <summary>
/// Defines the base contract for CLR element specifiers
/// </summary>
public interface IClrElementSpec : IValueObject
{
    /// <summary>
    /// The name of the element being specified
    /// </summary>
    IClrElementName ElementName { get; }

    /// <summary>
    /// Optional element documentation
    /// </summary>
    Option<CodeDocumentationSpec> Documentation { get; }

    /// <summary>
    /// Attributes applied to the element
    /// </summary>
    IReadOnlyList<AttributionSpec> Attributions { get; }

    /// <summary>
    /// The access level of the element
    /// </summary>
    ClrAccessKind AccessLevel { get; }
}


