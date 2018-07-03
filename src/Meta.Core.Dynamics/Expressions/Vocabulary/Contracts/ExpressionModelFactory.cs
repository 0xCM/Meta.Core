//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
 
    /// <summary>
    /// Defines contract for functions that create models from LINQ expression trees
    /// </summary>
    /// <typeparam name="M">The type of model the function will produce</typeparam>
    /// <param name="X">The expression from which the model's structure will be derived</param>
    /// <returns></returns>
    public delegate M ExpressionModelFactory<out M>(Expression X, params SelectionFacet[] facets);
}