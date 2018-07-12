//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public readonly struct FactoredTypeInfo
    {
        public FactoredTypeInfo(string TypeName, int ParameterCount)
        {
            this.TypeName = TypeName;
            this.ParameterNames = map(range(1, ParameterCount), i => $"X{i}");
        }

        public FactoredTypeInfo(string TypeName, params string[] ParameterNames)
        {
            this.TypeName = TypeName;
            this.ParameterNames = ParameterNames;
        }

        public string TypeName { get; }

        public Lst<string> ParameterNames { get; }

        public override string ToString()
            => concat($"{TypeName}", angled(join(comma(), ParameterNames.AsArray())));
    }

 
}