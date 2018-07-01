//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

/// <summary>
/// Encodes a value as an instance of a <see cref="CoreDataType"/>
/// </summary>
public sealed class CoreDataValue : ValueObject<CoreDataValue>
{

    public static readonly CoreDataValue Empty 
        = new CoreDataValue(CoreDataTypes.Unspecified.CreateReference(), null);

    /// <summary>
    /// Interprets a <see cref="object"/> value as a <see cref="CoreDataType"/> value
    /// </summary>
    /// <param name="x">The value to interpret</param>
    /// <returns></returns>
    /// <remarks>
    /// Obviously, this is dangerous and non-optimal for performance
    /// </remarks>
    static CoreDataValue ToCoreValue(object x)
    {
        var type = x?.GetType();

        if (type == typeof(Type))
            return ((Type)x).AsCoreValue();
        else if (type == typeof(byte[]))
            return ((byte[])x).AsCoreValue();

        else if (type == typeof(short?))
            return ((short?)x).AsCoreValue();
        else if (type == typeof(short))
            return ((short)x).AsCoreValue();

        else if (type == typeof(Guid?))
            return ((Guid?)x).AsCoreValue();
        else if (type == typeof(Guid))
            return ((Guid)x).AsCoreValue();

        else if (type == typeof(byte?))
            return ((byte?)x).AsCoreValue();
        else if (type == typeof(byte))
            return ((byte)x).AsCoreValue();

        else if (type == typeof(int?))
            return ((int?)x).AsCoreValue();
        else if (type == typeof(int))
            return ((int)x).AsCoreValue();

        else if (type == typeof(long?))
            return ((long?)x).AsCoreValue();
        else if (type == typeof(long))
            return ((long)x).AsCoreValue();

        else if (type == typeof(uint?))
            return ((uint?)x).AsCoreValue();
        else if (type == typeof(uint))
            return ((uint)x).AsCoreValue();

        else if (type == typeof(ulong?))
            return ((ulong?)x).AsCoreValue();
        else if (type == typeof(ulong))
            return ((ulong)x).AsCoreValue();

        else if (type == typeof(DateTime?))
            return ((DateTime?)x).AsCoreValue();
        else if (type == typeof(DateTime))
            return ((DateTime)x).AsCoreValue();

        else if (type == typeof(Date?))
            return ((Date?)x).AsCoreValue();
        else if (type == typeof(Date))
            return ((Date)x).AsCoreValue();

        else if (type == typeof(double?))
            return ((double?)x).AsCoreValue();
        else if (type == typeof(double))
            return ((double)x).AsCoreValue();

        else if (type == typeof(float?))
            return ((float?)x).AsCoreValue();
        else if (type == typeof(float))
            return ((float)x).AsCoreValue();

        else if (type == typeof(decimal?))
            return ((decimal?)x).AsCoreValue();
        else if (type == typeof(decimal))
            return ((decimal)x).AsCoreValue();

        else if (type == typeof(bool?))
            return ((bool?)x).AsCoreValue();
        else if (type == typeof(bool))
            return ((bool)x).AsCoreValue();

        else if (type == typeof(string))
            return ((string)x).AsCoreValue();

        else if (type.IsEnum)
            return ((Enum)x).AsCoreValue();

        else if (type.Name == "SqlRowVersion")
            return ((byte[])(((dynamic)x).ConvertTo(typeof(byte[])))).AsCoreValue();

        return Empty;
    }

    public static CoreDataValue Require(object x)
        => FromObject(x).Require();

    public static Option<CoreDataValue> FromObject(object x)
        => isNull(x) 
        ? none<CoreDataValue>(error("Argument null")) 
        : Try(() => ToCoreValue(x));

    public static Option<CoreDataValue[]> FromObjects(object[] objects)
    {
        var values = map(objects, o => FromObject(o));
        if (values.Any(v => v.IsNone()))
            return none<CoreDataValue[]>(values.First(v => v.IsNone()).Message);
        else
            return map(values, value => ~value).ToArray();
    }
        

    public static implicit operator CoreDataValue(string x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(bool x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(bool? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(byte x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(byte? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(short x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(short? x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(int x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(int? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(uint x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(uint? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(long x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(long? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(ulong x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(ulong? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(decimal x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(decimal? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(double x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(double? x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(float x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(float? x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(Guid x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(Guid? x)
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(Date x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(Date? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(DateTime x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(DateTime? x) 
        => x.AsCoreValue();

    public static implicit operator CoreDataValue(Type x)
        => x.AsCoreValue();

    public static implicit operator int?(CoreDataValue x)
        => x.ToClrValue<int?>();

    public readonly CoreTypeReference DataType;
    public readonly string ValueAsText;

    public CoreDataValue(CoreTypeReference DataType, string ValueAsText)
    {
        this.DataType = DataType;
        this.ValueAsText = ValueAsText;
    }

    public override string ToString()
        => ValueAsText;

    public object ToClrValue() 
        => DataType.CoreType.FromText(ValueAsText);

    public V ToClrValue<V>()
        => (V)DataType.CoreType.FromText(ValueAsText);

    /// <summary>
    /// The CLR type of the represented value
    /// </summary>
    public ClrType ClrType
        => ClrType.Get(DataType.ReferencedType.ClrType);

    public bool IsText
        => DataType.ReferencedType.IsText;

    public bool IsTemporal
        => DataType.ReferencedType.IsTemporal;

    public bool IsInteger
        => DataType.ReferencedType.IsInteger;

    public bool IsBoolean
        => DataType.ReferencedType.IsBoolean;

    public bool IsEmpty
        => DataType.ReferencedType.Equals(CoreDataTypes.Unspecified);


}

