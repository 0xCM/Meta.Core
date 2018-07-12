//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Workflow;

    class SqlDataFlowProvider : ApplicationService<SqlDataFlowProvider, ISqlDataFlowProvider>, ISqlDataFlowProvider
    {
        static Option<Type> SearchForType(IEnumerable<Assembly> assemblies, SystemUri TypeUri)
        {
            var query = from a in assemblies
                        from t in a.GetTypes()
                        let candidiate = t.Uri()
                        where TypeUri == candidiate
                        select t;
            return query.TryGetFirst();
        }

        public SqlDataFlowProvider(IApplicationContext C)
            : base(C)
        {
            DataFlows = C.SystemReflector().DataFlows.ToReadOnlyList();
        }

        IEnumerable<SqlDataFlowDescriptor> DataFlows { get; }
            
        public Option<ISqlDataFlow> FromType<F>(NodeLink Link)
        {
            try
            {
                var wfContext = new LinkedContext(C, Link);
                var instance = Activator.CreateInstance(typeof(F), array<object>(wfContext));
                return some(instance as ISqlDataFlow);
            }
            catch(Exception e)
            {
                return none<ISqlDataFlow>(e);
            }
        }

        public Option<ISqlDataFlow> CreateDataFlow(NodeLink Link, SystemUri Uri)
            => from df  in DataFlows.Where(f => f.ImplementingType.Uri() == Uri.TrimQuery()).TryGetFirst()
               let wfContext = new LinkedContext(C, Link)
               let instance = Activator.CreateInstance(df.ImplementingType, array<object>(wfContext))
               select instance as ISqlDataFlow;                  
    }
}