//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;
    using MetaFlow.Core;

    using static metacore;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class PlatformSystemAttribute : Attribute
    {
        public PlatformSystemAttribute(PlatformSystemKind Classification)
        {
            this.Classification = Classification;
        }

        public PlatformSystemKind Classification { get; }
    }
}