//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using SqlT.Core;
    using Meta.Core;
    
    using static metacore;

    public static partial class SqlProxyX
    {
        public static Dst Combine<Src1, Src2, Dst>(this (Src1 x, Src2 y, Dst xy) AB)
            where Src1 : ISqlTabularProxy
            where Src2 : ISqlTabularProxy
            where Dst : ISqlTabularProxy
        {
            var xData = AB.x.GetItemArray();
            var yData = AB.y.GetItemArray();
            var dstData = xData.Append(yData);
            var dst = AB.xy;
            dst.SetItemArray(dstData);
            return dst;
        }

        public static string MD5(this ISqlProxy proxy)
            => IdentifyingHash.HashItems(proxy.GetItemArray());

        public static bool IsProxyAssembly(this Assembly a)
            => a.HasAttribute<SqlProxyAssemblyAttribute>();

        public static bool IsProxyAssembly(this ClrAssembly a)
            => a.ReflectedElement.IsProxyAssembly();
    }
}
