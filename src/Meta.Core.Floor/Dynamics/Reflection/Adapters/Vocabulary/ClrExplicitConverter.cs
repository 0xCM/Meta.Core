//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using static metacore;




/// <summary>
/// Defines a convenience adapter for <see cref="MethodInfo"/> values that
/// describe explicit conversion operators
/// </summary>
public sealed class ClrExplicitConverter : ClrConversionOperator
{

    public ClrExplicitConverter(MethodInfo ReflectedElement)
        : base(ReflectedElement)
    {

    }


    public override ConversionOperatorKind ConversionKind
        => ConversionOperatorKind.Explicit;
}

