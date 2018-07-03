//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;

    using Modules;
    /// <summary>
    /// Represents a logical connective where each constituent is a member predicate
    /// </summary>
    public abstract class Junction : IJunction
    {
        protected Junction(IEnumerable<IPredicateAplication> Criteria, Junction Parent = null)
        {
            this.Criteria = MutableList.FromItems(Criteria.ToList());
            this.Parent = Parent;
            this.Children = MutableList.Create<Junction>();
        }

        protected abstract ILogicalOperator Connective { get; }

        public MutableList<IPredicateAplication> Criteria { get; }

        public Option<Junction> Parent { get; }

        public MutableList<Junction> Children { get; }

        IReadOnlyList<IPredicateAplication> IJunction.Criteria
            => Criteria;

        public void Flatten()
        {
            if (Children.Count == 1 && Children[0].Connective == Connective)
            {
                var child = Children[0];
                Criteria.AddRange(child.Criteria);
                Children.Clear();
                Children.AddRange(child.Children);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Parent.Exists)
                sb.Append("(");
            try
            {
                for (int i = 0; i < Criteria.Count; i++)
                {
                    var p = Criteria[i];
                    if (i == 0)
                        sb.Append($"{p} {Connective.Symbol}");
                    else if (i != Criteria.Count - 1)
                        sb.Append($" {p} {Connective.Symbol}");
                    else
                        sb.Append($" {p}");
                }
                if (Children.Count != 0)
                {
                    foreach (var child in Children)
                    {
                        sb.Append(child.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                sb.Append(e.Message);
            }

            if (Parent.Exists)
                sb.Append(")");

            return sb.ToString();

        }
    }
}
