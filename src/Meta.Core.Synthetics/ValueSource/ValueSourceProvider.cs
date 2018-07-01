//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using static metacore;

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