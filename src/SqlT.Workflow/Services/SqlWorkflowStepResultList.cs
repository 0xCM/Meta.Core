//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Meta.Core.Workflow;
    using SqlT.Core;
    using static metacore;

    using SR = SqlWorkflowStepResult;


    public class SqlWorkflowStepResultList<P> :  IReadOnlyList<SqlWorkflowStepResult<P>>
    {

        ReadOnlyList<SqlWorkflowStepResult<P>> Results { get; }

        public SqlWorkflowStepResultList(IEnumerable<SqlWorkflowStepResult<P>> Results)
        {
            this.Results = Results.ToReadOnlyList();
        }

        SqlWorkflowStepResult<P> IReadOnlyList<SqlWorkflowStepResult<P>>.this[int index] 
            => Results[index];

        int IReadOnlyCollection<SqlWorkflowStepResult<P>>.Count
            => (this as IReadOnlyList<SR>).Count;

        IEnumerator<SqlWorkflowStepResult<P>> IEnumerable<SqlWorkflowStepResult<P>>.GetEnumerator()
            => new ReadOnlyList<SqlWorkflowStepResult<P>>(Results.Cast<SqlWorkflowStepResult<P>>()).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Results.GetEnumerator();
    }

    public class SqlWorkflowStepResultList : IReadOnlyList<SR>
    {


        public SqlWorkflowStepResultList(IEnumerable<SR> Results)
        {
            this.Results = Results.ToReadOnlyList();
        }

        protected ReadOnlyList<SR> Results { get; }


        public IEnumerable<SqlWorkflowStepSuccess<P>> Successes<P>()
            => Results.OfType<SqlWorkflowStepSuccess<P>>();


        public IEnumerable<SqlWorkflowStepFailure> Failures()
            => Results.OfType<SqlWorkflowStepFailure>();

        public SR this[int index]
            => ((IReadOnlyList<SR>)Results)[index];

        int IReadOnlyCollection<SR>.Count
            => ((IReadOnlyList<SR>)Results).Count;


        IEnumerator<SR> IEnumerable<SR>.GetEnumerator()
            => ((IReadOnlyList<SR>)Results).GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator()
            => ((IReadOnlyList<SR>)Results).GetEnumerator();

    }

}