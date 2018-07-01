//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public class CoreDataFacets : ValueObject<CoreDataFacets>
{
    const string RequiredLabel = "required";
    const string OptionalLabel = "optional";

    public readonly int? MaxLength;
    public readonly byte? NumericPrecision;
    public readonly byte? NumericScale;
    public readonly bool IsValueRequired;

    public CoreDataFacets
    (
        int? MaxLength = null,
        byte? NumericPrecision = null,
        byte? NumericScale = null,
        bool IsValueRequired = true
    )
    {
        this.MaxLength = MaxLength;
        this.NumericPrecision = NumericPrecision;
        this.NumericScale = NumericScale;
        this.IsValueRequired = IsValueRequired;
    }

    string RequiredDescription
        => IsValueRequired ? RequiredLabel : OptionalLabel;

    public bool IsValueOptional 
        => !IsValueRequired;

    public override string ToString() 
        => $"({ MaxLength ?? -1 }, {NumericPrecision ?? -1}, {NumericScale ?? -1}, {RequiredDescription})";

    public bool AnySpecified 
        => MaxLength != null || NumericScale != null || NumericPrecision != null;
}
