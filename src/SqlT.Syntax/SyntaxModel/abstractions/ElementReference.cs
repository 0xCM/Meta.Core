//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;

    public abstract class ElementReference<N> : SyntaxExpression<ElementReference<N>>, IModelReference<N>
        where N : IName, new()
    {
        protected ElementReference(N Referent, string Alias = null)
        {
            this.Referent = Referent;
            this.Alias = Alias ?? string.Empty;
        }

        public N Referent { get; }

        public string Alias { get; }

        IName IModelReference.Referent
            => Referent;

        ISyntaxExpression IUnaryExpression.Operand
            => new name_expression(Referent);

        public override string ToString()
            => string.IsNullOrWhiteSpace(Alias)
            ? Referent.ToString()
            : $"{Referent} as {Alias}";
    }
}