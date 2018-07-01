//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// Defines a convenience adapter for <see cref="MethodInfo"/> values that
/// describe conversion operators
/// </summary>
public abstract class ClrConversionOperator : ClrMethod
{
    protected ClrConversionOperator(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }

    /// <summary>
    /// The type of element to be converted
    /// </summary>
    public ClrType SourceType
        => Parameters.Single().ParameterType;

    /// <summary>
    /// The type of the converted element
    /// </summary>
    public ClrType TargetType
        => ReturnType.ValueOrDefault();

    public abstract ConversionOperatorKind ConversionKind { get; }

    public override string ToString()
        => $"{SourceType.FormattedName} => {TargetType.FormattedName}";

}

public static class ClrConversionOperatorX
{
    /// <summary>
    /// Selects the converters that project to type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="ops"></param>
    /// <returns></returns>
    public static IEnumerable<ClrConversionOperator> Targets<T>(this IEnumerable<ClrConversionOperator> ops)
        => ops.Where(o => o.TargetType.IsTypeOf<T>());

    /// <summary>
    /// Selects the converters that project from the type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="ops"></param>
    /// <returns></returns>
    public static IEnumerable<ClrConversionOperator> Sources<T>(this IEnumerable<ClrConversionOperator> ops)
        => ops.Where(o => o.SourceType.IsTypeOf<T>());

}
