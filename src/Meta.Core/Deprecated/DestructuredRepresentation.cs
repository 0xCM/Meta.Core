//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

public sealed class DestructuredRepresentation : IRepresentation 
{
    public DestructuredRepresentation(string concreteTypeName, IEnumerable<RepresentationAttributeValue> attributes)
    {
        this.Attributes = attributes.ToList();
        this.ConcreteTypeName = concreteTypeName;
    }

    /// <summary>
    /// The name of the concrete runtime type that realizes the representation within the application
    /// </summary>
    public string ConcreteTypeName { get; }

    public IReadOnlyList<RepresentationAttributeValue> Attributes { get; }


}
