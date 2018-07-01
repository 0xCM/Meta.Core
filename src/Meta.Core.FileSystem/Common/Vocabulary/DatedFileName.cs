//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

/// <summary>
/// Defines a standard pattern for specifying filenames that include a date
/// </summary>
public sealed class DatedFileName : FileName<DatedFileName>
{
    static FileName Build(FileName UndatedName, Date? CreatedDate, DateRange? ContentDate)
    {
        if (not(CreatedDate.HasValue) && not(ContentDate.HasValue))
            return UndatedName;

        if (CreatedDate.HasValue)
        {
            if(not(ContentDate.HasValue))
                return new FileName($"{CreatedDate.Value.ToIsoString()}.{UndatedName}");

            Date min = ContentDate.Value.Min;
            Date max = ContentDate.Value.Max;
            if(min == max)
                return new FileName($"{CreatedDate.Value.ToIsoString()}.{UndatedName.RemoveExtension()}.{min.ToIsoString()}", UndatedName.Extension);
            return new FileName($"{CreatedDate.Value.ToIsoString()}.{UndatedName.RemoveExtension()}.{min.ToIsoString()}.{max.ToIsoString()}", UndatedName.Extension);
        }
        else
        {
            Date min = ContentDate.Value.Min;
            Date max = ContentDate.Value.Max;
            if (min == max)
                return new FileName($"{UndatedName.RemoveExtension()}.{min.ToIsoString()}", UndatedName.Extension);
            return new FileName($"{UndatedName.RemoveExtension()}.{min.ToIsoString()}.{max.ToIsoString()}", UndatedName.Extension);
        }
    }

    public DatedFileName()
        : base(String.Empty)
    {

    }

    public DatedFileName(FileName UndatedName)
        : base(Build(UndatedName, Date.Today, null))
    {}

    public DatedFileName(FileName UndatedName, Date CreatedDate)
        : base(Build(UndatedName, CreatedDate, null))
    {}

    public DatedFileName(FileName UndatedName, DateRange ContentDate)
        : base(Build(UndatedName, null, ContentDate))
    {}

    public DatedFileName(FileName UndatedName, Date CreatedDate, DateRange ContentDate)
        : base(Build(UndatedName, null, ContentDate))
    { }

    DatedFileName(string Value, FileExtension x)
        : base(Value, x)
    { }

    protected override Func<string, DatedFileName> Reconstructor 
        => text => new DatedFileName(text);
}