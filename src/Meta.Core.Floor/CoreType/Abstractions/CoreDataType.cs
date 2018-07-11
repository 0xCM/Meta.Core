//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

public delegate object CoreDataTypeConverter(CoreDataType srcType, object srcValue);

/// <summary>
/// Represents a fundamental data type that can be mapped to and from other type systems
/// </summary>
public abstract class CoreDataType : CoreType<CoreDataType>
{
    public static implicit operator string(CoreDataType src) 
        => src.DataTypeName;

    /// <summary>
    /// Initializes a new <see cref="CoreDataType"/> instance
    /// </summary>
    /// <param name="DataTypeName">The name of the data type</param>
    internal CoreDataType(string DataTypeName, Type ClrType)
        : base(DataTypeName, ClrType, false, false, false)
    {
    }

    internal CoreDataType(string DataTypeName, Type ClrType, bool CanSpecifyLength)
        : base(DataTypeName, ClrType, CanSpecifyLength, false, false)
    {
    }

    internal CoreDataType(string DataTypeName, Type ClrType,  bool CanSpecifyPrecision, bool CanSpecifyScale)
        : base(DataTypeName, ClrType, false, CanSpecifyPrecision, CanSpecifyScale)
    {
    }

    /// <summary>
    /// Converts a value of one type to a value of another type
    /// </summary>
    /// <param name="value">The value to convert</param>
    /// <param name="dstType">The target type</param>
    /// <returns></returns>
    public abstract object ConvertValue(object value, Type dstType);
}

/// <summary>
/// Base generic type for "active type classifiers"
/// </summary>
/// <typeparam name="T">The CLR data type on which the fundamental data type is based</typeparam>
/// <remarks>
/// Subtypes hold no data and exist for two reasons
/// 1. To classify
/// 2. To provide behavior for value within the domain of classification
/// This type hierarchy is for representation and modeling 
/// purposes and is not intended to serve as a means to adopt an object-based
/// runtime type system. As such, no siganificant quantities should
/// be represented by corresponding/affiliated <see cref="CoreDataValue"/> instances.
/// The typed collection <see cref="CoreDataTypes"/> defines a singleton
/// instance for each concrete subtype
/// </remarks>
public abstract class CoreDataType<T> : CoreDataType, ICoreType<ICoreType>
{

    protected CoreDataType(string DataTypeName)
        : base(DataTypeName, typeof(T))
    {
    }

    protected CoreDataType(string DataTypeName, bool CanSpecifyLength)
        : base(DataTypeName, typeof(T), CanSpecifyLength)
    {

    }

    protected CoreDataType(string DataTypeName, bool CanSpecifyPrecision, bool CanSpecifyScale)
        : base(DataTypeName, typeof(T),  CanSpecifyPrecision, CanSpecifyScale)
    {

    }

    public sealed override string ToText(object value)
    {
        if (IsText && value.GetType() != typeof(string))
            return value.ToString();
        else
            return CreateValueText((T)value);
    }
         
    public virtual string CreateValueText(T value) 
        => isNull(value) ? null : show(value);

    public ICoreType CoreType
        => this;

    public abstract T ParseTypedValue(string text);

    public sealed override object FromText(string value) 
        => ParseTypedValue(value);

    protected virtual object Convert(T srcValue, Type dstClrType) 
        => System.Convert.ChangeType(srcValue, dstClrType);

    public override sealed object ConvertValue(object value, Type dstClrType) 
        => ConvertValue((T)value, dstClrType);

    public object ConvertValue(T srcValue, Type dstClrType)
    {
        if (ClrType == dstClrType)
            return srcValue;
        else  if (srcValue == null)
            return null;
        else
            return Convert(srcValue, dstClrType);
    }            
}    

