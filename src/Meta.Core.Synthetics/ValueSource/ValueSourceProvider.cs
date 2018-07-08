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
    using System.Reflection;


    [Service(typeof(IValueSource))]
    class ValueSourceProvider : Service<IValueSource>, IValueSource
    {
        readonly IReadOnlyDictionary<Type, MethodInfo> GeneratorFactories;

        public ValueSourceProvider(IApplicationContext context)
            : base(context)
        {

            GeneratorFactories = new Dictionary<Type, MethodInfo>();
        }

        public Synthetic SyntheticValue(ValueSourceConfig settings)
            => Synthetic.Create(settings, GeneratorFactories);
    }
}