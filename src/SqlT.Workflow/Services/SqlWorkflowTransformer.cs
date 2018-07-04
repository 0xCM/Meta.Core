//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;
   

    using static metacore;

    public class SqlWorkflowTransformer<TSrc, TDst> : ApplicationComponent, 
            ISqlTransformer<TSrc, TDst>, 
            ISqlWorkflowTransformer
        
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()
    {

        List<ISqlProjection> steps = new List<ISqlProjection>();



        public SqlWorkflowTransformer(IApplicationContext C)
            : base(C)
        {

        }

        public void AppendInjection<X, Y>(Func<X, Y> f)
            where X : ISqlTabularProxy, new()
            where Y : ISqlTabularProxy, new()

        {
            steps.Add(f.DefineSqlProjection());
        }

        public void AppendInjection<X, Y>(Func<IEnumerable<X>, IEnumerable<Y>> f)
            where X : ISqlTabularProxy, new()
            where Y : ISqlTabularProxy, new()

        {
            steps.Add(f.DefineSqlProjection());
        }


        public IEnumerable<TDst> Push(IEnumerable<TSrc> src)
        {
            var input = src.Cast<ISqlTabularProxy>();
            foreach (var segment in steps)
                input = segment.Push(input);
            var output = input.Cast<TDst>();
            return output;
        }

    }








}
