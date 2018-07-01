//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

/// <summary>
/// Describes a data field
/// </summary>
public class CoreDataFieldDescription : ValueObject<CoreDataFieldDescription>
{
    /// <summary>
    /// The peer-relative position of the field
    /// </summary>
    public readonly int Position;

    /// <summary>
    /// The name of the field
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The <see cref="CoreDataType"/> of the field
    /// </summary>
    public readonly CoreDataType DataType;

    /// <summary>
    /// The applicable <see cref="CoreDataFacets"/>
    /// </summary>
    public Option<CoreDataFacets> DataFacets;

    /// <summary>
    /// Describes the purposes of the field
    /// </summary>
    public readonly string Documentation;

    /// <summary>
    /// Initializes a new <see cref="CoreDataFieldDescription"/> instance
    /// </summary>
    /// <param name="Position">The peer-relative position of the field</param>
    /// <param name="Name">The name of the field</param>
    /// <param name="DataType">The <see cref="CoreDataType"/> of the field</param>
    /// <param name="DataFacets">The applicable <see cref="CoreDataFacets"/></param>
    /// <param name="Documentation">Describes the purposes of the field</param>
    public CoreDataFieldDescription
        (
            int Position, 
            string Name, 
            CoreDataType DataType, 
            CoreDataFacets DataFacets = null, 
            string Documentation = null
        )
    {
        this.Position = Position;
        this.Name = Name;
        this.DataType = DataType;
        this.Documentation = Documentation ?? String.Empty;
        this.DataFacets = DataFacets;
    }

    /// <summary>
    /// Specifies whether the field is required
    /// </summary>
    public bool Required 
        => DataFacets.Map(f => f.IsValueRequired, () => true);

    /// <summary>
    /// Specifies whether the field is optional
    /// </summary>
    public bool Optional 
        => !Required;

    /// <summary>
    /// Creates a copy of the field while replacing the position with a new value
    /// </summary>
    public CoreDataFieldDescription Clone(int newPosition) 
        => new CoreDataFieldDescription(newPosition, Name, DataType, DataFacets.ValueOrDefault(), Documentation);

    public override string ToString()
        => $"{Position.ToString().PadLeft(3, '0')} {Name} : {DataType}";
}
