//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using static metacore;

    /// <summary>
    /// Specifies the order of a workflow step relative to its execution context
    /// </summary>
    public class StepOrderAttribute : WorkflowFacetAtribute
    {

        public StepOrderAttribute(int Order)
        {
            this.StepOrder = Order;
        }

        /// <summary>
        /// The relatative order
        /// </summary>
        public int StepOrder { get; }

        protected override object FacetValue
            => StepOrder;

        public override string ToString()
            => StepOrder.ToString();

    }

}