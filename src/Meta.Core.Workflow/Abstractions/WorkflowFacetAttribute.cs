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


    public interface IWorkflowFacetAttribute
    {
        FacetInfo Facet { get; }
    }

    public abstract class WorkflowFacetAtribute : Attribute, IWorkflowFacetAttribute
    {
        public static IEnumerable<FacetInfo> AppliedFacets(MemberInfo member)
            => from attribute in member.GetCustomAttributes<WorkflowFacetAtribute>(true).Cast<IWorkflowFacetAttribute>()
               select attribute.Facet;
               
        protected WorkflowFacetAtribute(string FacetName = null)
        {
            FacetName = ifBlank(FacetName, GetType().Name.Replace(nameof(Attribute), string.Empty));
        }

        public string FacetName { get; }

        protected abstract object FacetValue { get; }

        FacetInfo IWorkflowFacetAttribute.Facet
            => new FacetInfo(FacetName, FacetValue);

        public override string ToString()
            => (this as IWorkflowFacetAttribute).Facet.ToString();
    }

}