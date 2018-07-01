//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using static minicore;

    public class AssemblyTraverser
    {
        public ReadOnlyList<Action<Type>> TypeHandlers { get; }

        public AssemblyTraverser(IEnumerable<Action<Type>> TypeHandlers)
        {
            this.TypeHandlers = TypeHandlers.ToReadOnlyList();
        }

        Option<Unit> TraverseType(Type t)
            => Try(() => iter(TypeHandlers, h => h(t)));


        public Option<Unit> Traverse(params Assembly[] assemblies)
        {
            var errors = new ConcurrentBag<Exception>();
            assemblies.AsParallel().ForAll(a =>
            {
                try
                {
                    a.GetTypes().AsParallel()
                                .ForAll(t => TraverseType(t)
                                .OnNone(message => new Exception(message.Format(false))));    
                }
                catch(Exception e)
                {
                    errors.Add(e);
                }

            });

            return errors.Any() 
                ? none<Unit>(errors.First()) 
                : some(Unit.Value);
        }

    }


}