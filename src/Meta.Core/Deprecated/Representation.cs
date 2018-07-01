//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;

using static minicore;

/// <summary>
/// Base type for representations where a "representation" is intended to align, more or less, 
/// with Fielding's original definition of the term.
/// </summary>
/// <remarks>
/// In more detail: Fielding defined a representation as  "..a sequence of bytes, plus representation 
/// metadata to describe those bytes...a representation consists of data, metadata describing those 
/// metadata, and, on occasion, metadata to describe the metadata."
/// </remarks>
public abstract class Representation :  IRepresentation
{
    /// <summary>
    /// Identifies and describes an attribute defined by a representation
    /// </summary>
    /// <remarks>
    /// This is a really unfortunate name, but I see no way around it; however it's defined
    /// as a nested type here to minimize usage of the full name
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class AttributeAttribute : Attribute
    {
        /// <summary>
        /// The peer-relative position of the attribute
        /// </summary>
        public int Postion { get; set; }

        /// <summary>
        /// Documentation for the attribute
        /// </summary>
        public string Documentation { get; set; }


        /// <summary>
        /// The display name of the attribute
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Initializes a new <see cref="AttributeAttribute"/> type
        /// </summary>
        /// <param name="position">The peer-relative position of the attribute</param>
        /// <param name="documentation">Documentation for the attribute</param>
        /// <param name="displayName">The (non-semantic) attribute display name</param>
        public AttributeAttribute(int position, string documentation = "", string displayName = "")
        {
            this.Postion = position;
            this.Documentation = documentation;
            this.DisplayName = displayName;
        }
    }

    protected IReadOnlyDictionary<PropertyInfo, AttributeAttribute> GetPropertyAttributions() 
        => GetType().GetPropertyAttributions<AttributeAttribute>();

    protected IEnumerable<RepresentationAttributeValue>  GetAttributeValues(IReadOnlyDictionary<PropertyInfo, AttributeAttribute> attributions)
    {
        foreach (var attribution in attributions)
        {
            var prop = attribution.Key;
            var attrib = attribution.Value;
            var value = prop.GetValue(this);
            if (value != null)
                yield return new RepresentationAttributeValue(attrib.Postion, prop.Name, value);
        }

    }

    public virtual Option<TKey> GetKey<TKey>() 
        => none<TKey>();
    
    /// <summary>
    /// Gets the values of the parameters defined by the representation
    /// </summary>
    /// <returns></returns>
    public virtual DestructuredRepresentation Destructure() 
        =>  new DestructuredRepresentation(GetType().FullName, GetAttributeValues(GetPropertyAttributions()));
}

/// <summary>
/// Base type for all representations
/// </summary>
/// <typeparam name="T">The specializing type</typeparam>
public abstract class Representation<T> : Representation where T : Representation<T>
{


}

/// <summary>
/// Delegate that produces a representation from a set of attributes
/// </summary>
/// <typeparam name="R">The representation type</typeparam>
/// <param name="attributes">The attributes from which the representation will be constructed</param>
/// <returns></returns>

public delegate R RepresentationFactory<R>(IEnumerable<RepresentationAttributeValue> attributes) where R : IRepresentation;


