//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    public static class SqlTemplateX
    {
        public static IReadOnlyDictionary<ValueMember, SqlTemplateParameterAttribute> 
            ParameterAttributions<M>(this ISqlGenerationContext gc) where M : SqlModel<M>
                =>(from m in SqlModel<M>.ValueMembers
                        let a = m.GetAttribute<SqlTemplateParameterAttribute>()
                        where a.IsSome()
                        select (m, a.ValueOrDefault())
              ).ToReadOnlyDictionary();

        public static IReadOnlyDictionary<string, object> GetTemplateArgIdx<M>(this M model, 
            IReadOnlyDictionary<ValueMember, SqlTemplateParameterAttribute> x)
        {
            var tuples = from m in x.Keys
                         let a = x[m]
                         let paramName = isBlank(a.ParameterName) ? m.Name : a.ParameterName
                         let paramValue = m.GetValue(model)
                         select (paramName, paramValue);
            return (tuples).ToReadOnlyDictionary();
        }

        public static Option<V> DefaultTemplateParameterValue<M, V>(this ISqlGenerationContext GC,  SqlModel<M> model, Expression<Func<M, V>> selector)
            where M : SqlModel<M>
        {
            var member = selector.TryGetAccessedMember().Map(m => m.Name, () => String.Empty);
            if (isNotBlank(member))
            {
                var attributions = GC.ParameterAttributions<M>();
                if (attributions.Keys.Where(k => k.Name == member).Any())
                {
                    var key = attributions.Keys.Single(x => x.Name == member);
                    var attrib = attributions[key];
                    if (attrib.DefaultValue != null)
                    {
                        return some((V)attrib.DefaultValue);
                    }
                }
            }
            return none<V>();
        }

        public static Option<Y> GetTemplateParameterOption<M, Y>(this ISqlGenerationContext GC, SqlModel<M> model, Expression<Func<M, Y>> selector)
            where M : SqlModel<M>

        {
            var member = selector.GetValueMember();
            var value = member.GetValue<Y>(model);
            var option = value != null 
                ? some(value) 
                : GC.DefaultTemplateParameterValue(model,selector);
            return option;
        }
    }
}
