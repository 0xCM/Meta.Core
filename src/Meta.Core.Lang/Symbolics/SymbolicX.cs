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
    

    using static metacore;

    public static class VariableX
    {

        public static V Evaluate<V>(this ISymbolicExpression var, IValueResolver Resolver, IValueAggregator<V> aggregator)
        {

            var expansion = rolist(var.Expand());
            var resolutions = array(expansion.Select(x => Resolver.ResolveValue<V>(x)));
            var aggregate = aggregator.Aggregate(resolutions);
            return aggregate;
            
        }

                                          
        public static IEnumerable<ISymbolicExpression> ExpandComponents(this ISymbolicExpression var)
        {
            IEnumerable<ISymbolicExpression> ExpandChildren(ISymbolicExpression root)
            {
                foreach (var x in root.Components)
                {
                    yield return x;
                    if (x is ISymbolicExpression)
                    {
                        foreach (var y in ExpandChildren(x as ISymbolicExpression))
                            yield return y;
                    }
                }
            }

            foreach (var child in var.Components)
            {
                yield return child;
                if (child is ISymbolicExpression)
                {
                    foreach (var grandchild in ExpandChildren(child as ISymbolicExpression))
                        yield return grandchild;
                }
            }
        }

        public static IEnumerable<ISymbolicExpression> Expand(this ISymbolicExpression var)
        {
            yield return var;

                foreach (var expansion in (var as ISymbolicExpression).ExpandComponents())
                    yield return expansion;
        }

    }

}