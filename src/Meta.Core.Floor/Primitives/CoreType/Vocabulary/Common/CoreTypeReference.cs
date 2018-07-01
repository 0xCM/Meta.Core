//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

/// <summary>
/// Represents a reference to a core data type
/// </summary>
public class CoreTypeReference : ValueObject<CoreTypeReference>
{

    public ClrTypeReference ClrType { get; }

    ICoreType<ICoreType> _ReferencedType { get; }

    public ICoreType<ICoreType> CoreType
        => _ReferencedType;
        
    public ICoreType ReferencedType
        => _ReferencedType.CoreType;

    public Option<CoreDataFacets> Facets { get; }

    public bool ValueRequired { get; }


    public CoreTypeReference(ICoreType<ICoreType> ReferencedType, CoreDataFacets Facets = null, bool ValueRequired = true)
    {
        if(Facets != null)
        {
            if (Facets.MaxLength != null && not(ReferencedType.CoreType.CanSpecifyLength))
                throw new ArgumentException();
            if (Facets.NumericPrecision != null && not(ReferencedType.CoreType.CanSpecifyPrecision))
                throw new ArgumentException();
            if (Facets.NumericScale != null && not(ReferencedType.CoreType.CanSpecifyScale))
                throw new ArgumentException();

        }
        this._ReferencedType = ReferencedType;
        this.Facets = Facets;
        this.ValueRequired = ValueRequired;
        this.ClrType = global::ClrType.Get(ReferencedType.CoreType.ClrType).GetReference();
    }

    public override string ToString()
    {
        var required = ValueRequired ? "Required" : "Optional";
        return $"{_ReferencedType}{Facets} ({required})";
    }

    public string DataTypeName 
        => _ReferencedType.CoreType.DataTypeName;

    /// <summary>
    /// Creates a value of the type
    /// </summary>
    /// <param name="value">The value to encode</param>
    /// <returns></returns>
    public CoreDataValue CreateValue(object value) 
        => new CoreDataValue(this, _ReferencedType.ToText(value));
}

