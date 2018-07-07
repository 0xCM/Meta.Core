//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;


public interface ICoreTypeOps
{
    /// <summary>
    /// Materializes a value of the type from a text representation
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    object FromText(string text);

    /// <summary>
    /// Represents a value of the type as text
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns></returns>
    string ToText(object value);

    /// <summary>
    /// Creates a <see cref="CoreTypeReference"/> to the type
    /// </summary>
    /// <param name="required">Whether a value is required</param>
    /// <param name="precision">The precision if applicable</param>
    /// <param name="scale">The scale if applicable</param>
    /// <param name="length">The length if applicable</param>
    /// <returns></returns>
    CoreTypeReference CreateReference(bool required = true, int? length = null, byte? precision = null, byte? scale = null);

    /// <summary>
    /// Creates a <see cref="CoreTypeReference"/> to the type
    /// </summary>
    /// <param name="facets"></param>
    /// <returns></returns>
    CoreTypeReference CreateReference(CoreDataFacets facets);

}

