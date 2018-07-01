//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;


/// <summary>
/// Defines a convenience adapter for <see cref="MethodInfo"/> values that
/// describe implicit conversion operators
/// </summary>
public sealed class ClrImplictConverter : ClrConversionOperator
{

    public ClrImplictConverter(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }

    public override ConversionOperatorKind ConversionKind
        => ConversionOperatorKind.Implicit;
}



