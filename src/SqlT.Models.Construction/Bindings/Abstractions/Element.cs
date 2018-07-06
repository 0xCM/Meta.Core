//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{

    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using System;
    using System.ComponentModel;
    using System.Collections.Generic;

    using Meta.Core;
    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    partial class TypeStructures
    {
        public abstract class Element<T, M, N> : IElement<N>
            where T : Element<T, M, N>, new()
            where M : IModel
            where N : IName
        {
            protected ClrProperty Property(Expression<Func<T, object>> Selector)
                => ClrProperty.Get(Selector.GetMember() as PropertyInfo);

            protected IEnumerable<ClrProperty> Properties(params Expression<Func<T, object>>[] Selectors)
                =>  Selectors.Select(s => ClrProperty.Get(s.GetMember() as PropertyInfo));

            protected Element()
            {
                this.Description = GetType().GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
                   
            }

            public abstract N Name { get; }

            public abstract M CreateModel();

            public SqlElementDescription Description { get; }

            IName IElement.Name
                => Name;

            IModel IElement.CreateModel()
                => CreateModel();

            public override string ToString()
                => Name.ToString();
        }
    }
}