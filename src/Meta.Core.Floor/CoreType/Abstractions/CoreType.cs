//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;

/// <summary>
/// Ultimate base type for intrinsic and custom types
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
public abstract class CoreType<T> : ValueObject<T>, ICoreType, ICoreType<ICoreType>
    where T : CoreType<T>

{

    protected CoreType(string DataTypeName, Type ClrType, bool CanSpecifyLength, bool CanSpecifyPrecision, bool CanSpecifyScale)
    {
        this.DataTypeName = DataTypeName;
        this.ClrType = ClrType;
        this.CanSpecifyLength = CanSpecifyLength;
        this.CanSpecifyPrecision = CanSpecifyPrecision;
        this.CanSpecifyScale = CanSpecifyScale;
    }

    public string DataTypeName { get; }

    public Type ClrType { get; }

    public bool CanSpecifyLength { get; }

    public bool CanSpecifyPrecision { get; }

    public bool CanSpecifyScale { get; }

    /// <summary>
    /// Materializes a value of the type from a text representation
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public abstract object FromText(string value);

    /// <summary>
    /// Represents a value of the type as text
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns></returns>
    public abstract string ToText(object value);

    /// <summary>
    /// Specifies whether the type is integral
    /// </summary>
    public virtual bool IsInteger 
        => false;

    /// <summary>
    /// Specifies whether the type is boolean
    /// </summary>
    public virtual bool IsBoolean 
        => false;

    /// <summary>
    /// Specifies whether an instance of the type is a date/datetime/time value
    /// </summary>
    public virtual bool IsTemporal
        => false;

    /// <summary>
    /// Specifies whether the type is text-based
    /// </summary>
    public virtual bool IsText 
        => false;

    string ICoreType.DataTypeName 
        => DataTypeName;

    Type ICoreType.ClrType 
        => ClrType;

    bool ICoreType.CanSpecifyLength 
        => CanSpecifyLength;

    bool ICoreType.CanSpecifyPrecision 
        => CanSpecifyPrecision;

    bool ICoreType.CanSpecifyScale 
        => CanSpecifyScale;

    bool ICoreType.IsBoolean
        => IsBoolean;

    ICoreType ICoreType<ICoreType>.CoreType
        => this;

    object ICoreTypeOps.FromText(string text) 
        => FromText(text);

    /// <summary>
    /// Creates a <see cref="CoreTypeReference"/> to the type
    /// </summary>
    /// <param name="required">Whether a value is required</param>
    /// <param name="precision">The precision if applicable</param>
    /// <param name="scale">The scale if applicable</param>
    /// <param name="length">The length if applicable</param>
    /// <returns></returns>
    public CoreTypeReference CreateReference(bool required = true, int? length = null, byte? precision = null, byte? scale = null) =>
        new CoreTypeReference
        (
            ReferencedType: this,
            Facets: new CoreDataFacets(NumericScale: scale, NumericPrecision: precision, MaxLength: length, IsValueRequired: required),
            ValueRequired: required
        );

    public CoreTypeReference CreateReference(CoreDataFacets facets) 
        => new CoreTypeReference
        (
            ReferencedType: this,
            Facets: facets,
            ValueRequired: facets.IsValueRequired
        );

    public override string ToString()
        => DataTypeName;
}

