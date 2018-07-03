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
    using System.Diagnostics;


    using Modules;
    using X = System.Linq.Expressions;

    using static minicore;


    class LinqExpressionVisitor : ExpressionVisitor
    {
        MutableList<object> traversals = MutableList.Create<object>();

        void TraceVisit(Expression X)
        {
            var message = $"Visited {X.GetType().Name} node of type {X.NodeType}";
            traversals.Add(X);
            Debug.WriteLine(message);
        }

        void TraceVisit(CatchBlock B)
        {
            var message = $"Visited catch block";
            traversals.Add(B);
            Debug.WriteLine(message);
        }

        void TraceVisit(ElementInit I)
        {
            var message = $"Visited element init";
            traversals.Add(I);
            Debug.WriteLine(message);
        }

        void TraceVisit(MemberBinding B)
        {
            var message = $"Visited member binding";
            traversals.Add(B);
            Debug.WriteLine(message);
        }


        public LinqExpressionVisitor()
        {

        }

        public event Action<MethodCallExpression> MethodCallExpressionTraversed;
        public event Action<BinaryExpression> BinaryExpressionTraversed;
        public event Action<ConstantExpression> ConstantExpressionTraversed;
        
        protected override Expression VisitBinary(BinaryExpression X)
        {
            TraceVisit(X);

            BinaryExpressionTraversed?.Invoke(X);


            return base.VisitBinary(X);
        }

        protected override Expression VisitBlock(BlockExpression X)
        {
            TraceVisit(X);

            return base.VisitBlock(X);
        }

        protected override Expression VisitConditional(ConditionalExpression X)
        {
            TraceVisit(X);

            return base.VisitConditional(X);
        }

        protected override CatchBlock VisitCatchBlock(CatchBlock B)
        {
            TraceVisit(B);

            return base.VisitCatchBlock(B);
        }

        protected override Expression VisitConstant(ConstantExpression X)
        {
            TraceVisit(X);

            ConstantExpressionTraversed?.Invoke(X);

            return base.VisitConstant(X);
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression X)
        {
            TraceVisit(X);

            return base.VisitDebugInfo(X);
        }

        protected override Expression VisitDefault(DefaultExpression X)
        {
            TraceVisit(X);

            return base.VisitDefault(X);
        }

        protected override Expression VisitDynamic(DynamicExpression X)
        {
            TraceVisit(X);

            return base.VisitDynamic(X);
        }

        protected override ElementInit VisitElementInit(ElementInit X)
        {
            TraceVisit(X);

            return base.VisitElementInit(X);
        }

        protected override Expression VisitGoto(GotoExpression X)
        {
            TraceVisit(X);

            return base.VisitGoto(X);
        }

        protected override Expression VisitExtension(Expression X)
        {
            TraceVisit(X);

            return base.VisitExtension(X);
        }

        protected override Expression VisitMember(MemberExpression X)
        {
            TraceVisit(X);

            return base.VisitMember(X);
        }

        protected override Expression VisitSwitch(SwitchExpression X)
        {
            TraceVisit(X);

            return base.VisitSwitch(X);
        }

        protected override Expression VisitIndex(IndexExpression X)
        {
            TraceVisit(X);

            return base.VisitIndex(X);
        }

        protected override Expression VisitInvocation(InvocationExpression X)
        {
            TraceVisit(X);

            return base.VisitInvocation(X);
        }

        protected override Expression VisitListInit(ListInitExpression X)
        {
            TraceVisit(X);

            return base.VisitListInit(X);
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment X)
        {
            TraceVisit(X);

            return base.VisitMemberAssignment(X);
        }

        protected override Expression VisitLoop(LoopExpression X)
        {
            TraceVisit(X);

            return base.VisitLoop(X);
        }

        protected override MemberBinding VisitMemberBinding(MemberBinding X)
        {
            TraceVisit(X);

            return base.VisitMemberBinding(X);
        }

        protected override Expression VisitMemberInit(MemberInitExpression X)
        {
            TraceVisit(X);

            return base.VisitMemberInit(X);
        }

        protected override Expression VisitLambda<T>(Expression<T> X)
        {
            TraceVisit(X);

            return base.VisitLambda(X);
        }

        protected override LabelTarget VisitLabelTarget(LabelTarget X)
        {

            return base.VisitLabelTarget(X);
        }

        protected override Expression VisitLabel(LabelExpression X)
        {
            TraceVisit(X);

            return base.VisitLabel(X);
        }

        protected override Expression VisitMethodCall(MethodCallExpression X)
        {
            TraceVisit(X);

            MethodCallExpressionTraversed?.Invoke(X);

            return base.VisitMethodCall(X);
        }

        protected override Expression VisitNew(NewExpression X)
        {
            TraceVisit(X);

            return base.VisitNew(X);
        }

        protected override MemberListBinding VisitMemberListBinding(MemberListBinding X)
        {
            TraceVisit(X);

            return base.VisitMemberListBinding(X);
        }

        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding X)
        {
            TraceVisit(X);

            return base.VisitMemberMemberBinding(X);
        }

        protected override Expression VisitNewArray(NewArrayExpression X)
        {
            TraceVisit(X);

            return base.VisitNewArray(X);
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression X)
        {
            TraceVisit(X);

            return base.VisitTypeBinary(X);
        }

        protected override Expression VisitTry(TryExpression X)
        {
            TraceVisit(X);

            return base.VisitTry(X);
        }

        protected override Expression VisitParameter(ParameterExpression X)
        {
            TraceVisit(X);

            return base.VisitParameter(X);
        }

        protected override Expression VisitUnary(UnaryExpression X)
        {
            TraceVisit(X);

            return base.VisitUnary(X);
        }

        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression X)
        {
            TraceVisit(X);

            return base.VisitRuntimeVariables(X);
        }

        protected override SwitchCase VisitSwitchCase(SwitchCase X)
        {
            

            return base.VisitSwitchCase(X);
        }

        //public List<object> Traversals 
        //    => List.make(traversals);
    }

}