//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;


    using X = System.Linq.Expressions;
    using G = System.Collections.Generic;
    using static minicore;

    public class SelectionModelBuilder
    {
        public static ModelSpecifier<SelectionModel, T> Select<T>(params SelectionFacet[] facets)
            => ModelSpecifier.Create<SelectionModel, T>(new ModelQueryProvider<SelectionModel>(BuildModel));

        public static SelectionModel CreateModel<T>(IQueryable<T> q, params SelectionFacet[] facets)
            => (q.Provider as IModelQueryProvider).CreateModel<SelectionModel>(q.Expression, facets);
       
        static SelectionModel BuildModel(Expression X, params SelectionFacet[] facets)
        {
            var builder = new SelectionModelBuilder(X);
            var selection = new MemberSelection(builder.selections);
            var order = builder.orders.Count != 0 
                      ? some(new MemberOrdering(builder.orders)) 
                      : none<MemberOrdering>();

            iter(builder.junctions, j => j.Flatten());
            var model = new SelectionModel(X, selection, order, builder.junctions , facets);
            return model;
        }

        readonly G.List<SelectedMember> selections = new G.List<SelectedMember>();
        readonly IReadOnlyList<SelectionFacet> facets;
        readonly G.List<Junction> junctions = new G.List<Junction>();

        G.List<MemberItemOrder> orders = new G.List<MemberItemOrder>();
        Tuple<BinaryExpression, Junction> CurrentJunction;
       
        SelectionModelBuilder(Expression X, params SelectionFacet[] facets)
        {
            this.facets = facets.ToList();
            var visitor = new LinqExpressionVisitor();
            visitor.MethodCallExpressionTraversed += Traversed;
            visitor.BinaryExpressionTraversed += Traversed;
            visitor.ConstantExpressionTraversed += Traversed;
            visitor.Visit(X);
        }


        static bool SpecifiesMemberPredicate(BinaryExpression X)
            => X.Left.IsOneOf<NewExpression, ConstantExpression, MemberExpression>()
            && X.Right.IsOneOf<NewExpression, ConstantExpression, MemberExpression>();

        void DefinePredicate(IComparisonOperator op, BinaryExpression X)
        {
            if (!SpecifiesMemberPredicate(X))
                return;

            var member = X.TryGetAccessedMember();
            if (!member)
                return;

            var value = X.GetValue();
            if (!value)
                return;

            var predicate = MemberValuePredicate.Define(op, member.Require(), value.Require());
            if (CurrentJunction != null)
                CurrentJunction.Item2.Criteria.Add(predicate);

        }

        void DefinePredicate(INullityOperator op, BinaryExpression X)
        {
            if (!SpecifiesMemberPredicate(X))
                return;

            var member = X.TryGetAccessedMember();
            if (!member)
                return;

            var predicate = MemberPredicate.Define(op, member.Require());
            if (CurrentJunction != null)
                CurrentJunction.Item2.Criteria.Add(predicate);
        }

        void HandleMethodCall(OrderSpecificationMethod method, MethodCallExpression node)
        {
            var arguments = node.Arguments.ToList();
            if (arguments.Count != 2)
                return;

            var selector = (arguments[1] as UnaryExpression)?.Operand as LambdaExpression;
            if (selector == null)
                return;

            if (selector.Parameters.Count != 1)
                return;

            var property = selector.TryGetAccesedProperty().ValueOrDefault();
            if (property == null)
                return;

            var methodName = node.Method.Name;
            var type = selector.Parameters[0].Type;


            orders.Add(new MemberItemOrder(property, method.Direction));

            if (method.IsPrimary)
                orders
                    = mapi(orders.Reverse<MemberItemOrder>(), (i, e) => e.Clone(NewPrecedence: i)).ToList();
        }

        void HandleMethodCall(WhereMethod method, MethodCallExpression X)
        {
            var C = ((X.Arguments[1] as UnaryExpression)?.Operand as LambdaExpression)?.Body as BinaryExpression;
            if (C == null)
                return;

            if (C.IsConjunction())
            {
                CurrentJunction = Tuple.Create(C, (Junction)new Conjunction());
                junctions.Add(CurrentJunction.Item2);
            }
            else if (C.IsDisjunction())
            {
                CurrentJunction = Tuple.Create(C, (Junction)new Disjunction());
                junctions.Add(CurrentJunction.Item2);
            }
        }

        void HandleMethodCall(SelectMethod method, MethodCallExpression X)
        {            
            if (X.Arguments.Count != 2)
                return;
           
            var N = ((X.Arguments[1] as UnaryExpression)?.Operand as LambdaExpression)?.Body as NewExpression;
            if (N == null || N.Members.Count != N.Arguments.Count)
                return;

            for (var i = 0; i < N.Members.Count; i++)
            {
                var arg = N.Arguments[i] as MemberExpression;
                if (arg == null)
                    return;

                var srcMember = arg.Member;
                if (srcMember == null)
                    return;

                var dstMember = N.Members[i];
                if (dstMember == null)
                    return;

                selections.Add(new SelectedMember(srcMember, i, srcMember.Name == dstMember.Name ? String.Empty : dstMember.Name));
            }
        }

        void Traversed(ConstantExpression X)
        {
            //If selections have already been specified, ignore
            if (selections.Count != 0)
                return;

            if (not(X.Type.IsGenericType))
                return;

            if (X.Type.GetGenericTypeDefinition() != typeof(ModelSpecifier<,>))
                return;

            var subject = X.Type.GetGenericArguments()[1];
            var members = subject.GetProperties().Cast<MemberInfo>().Union(subject.GetFields());
            selections.AddRange(mapi(members, (i, m) => new SelectedMember(m, i)));
        }

        void Traversed(MethodCallExpression X)
        {
            var method = StandardMethods.TryFind(X.Method.Name).ValueOrDefault();
            if (method != null)
            {
                switch (method)
                {
                    case SelectMethod m: HandleMethodCall(m, X); break;
                    case WhereMethod m: HandleMethodCall(m, X); break;
                    case OrderSpecificationMethod m: HandleMethodCall(m, X); break;
                }
            }
            //StandardMethods.TryFind(X.Method.Name).OnSome(m => HandleMethodCall((dynamic)m, X));

        }

        void Traversed(BinaryExpression B)
        {
            if(CurrentJunction != null && CurrentJunction.Item1 != B)
            {
                if (B.OnConjunction(C =>
                 {
                     var c = new Conjunction(CurrentJunction.Item2);
                     CurrentJunction.Item2.Children.Add(c);
                     CurrentJunction = Tuple.Create(C, (Junction)c);
                 })) return ;


                if (B.OnDisjunction(D =>
                 {
                     var d = new Disjunction(CurrentJunction.Item2);
                     CurrentJunction.Item2.Children.Add(d);
                     CurrentJunction = Tuple.Create(D, (Junction)d);
                 })) return ;
            }

            if (B.OnComparisonOperator(C => DefinePredicate(C, B)))
                return ;

            if (B.OnNullityOperator(N => DefinePredicate(N, B)))
                return ;

            return ;
        }

        static void Parse<T>(Expression<Predicate<T>> p)
        {
            var visitor = new LinqExpressionVisitor();
            visitor.Visit(p);
        }

        
    }
}
