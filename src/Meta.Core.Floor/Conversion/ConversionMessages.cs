//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static metacore;

static class ConversionMessages
{

    public static IAppMessage ConversionInputNull(Type DstType)
        => error(@"The attempt to convert to a value of type @DstType failed as the input argument was NULL", new
        {
            DstType
        });

    public static IAppMessage ConversionUndefined(Type SrcType, Type DstType)
        => error(@"Conversion from @SrcType to @DstType is undefined", new
        {
            SrcType,
            DstType
        });


}
