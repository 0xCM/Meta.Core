//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public static class OperationSpecX
    {
        static object DefaultParser(ClrType dstType, string srcValue)
            => dstType.ParseMethod.Map(parse => parse.Invoke(srcValue),
                () => Convert.ChangeType(srcValue, dstType.ReflectedElement));

        public static IOption Execute(this ClrMethodCallDescription description, object host, OperationArgParser parser = null)
        {
            var parse = parser ?? DefaultParser;
            var method = description.Operation.Method;
            var args = description.Arguments;
            var argValues = map(args,
                arg => (arg.ParameterName.ToString(),
                parse(arg.ParameterType, arg.ArgumentValue)));
            return (IOption)method.ReflectedElement.Invoke(host, argValues.Select(x => x.Item2).ToArray());
        }

        public static IEnumerable<Option<ClrMethodCallDescription>> Describe<T>(this OperationWorkflow workflow)
        {
            var contract = DescribeContract<T>();
            var activeOps = workflow.Steps.Where(i => i.IsActive).ToList();
            var descriptions = from active in some(activeOps)
                               let xyz = activeOps.Select(
                                   execSpec =>
                                    from op in execSpec.DescribeOperation<T>()
                                    from inv in contract.DescribeInvocation(execSpec)
                                    select inv
                                   )
                               select xyz;
            return descriptions.ValueOrDefault(stream<Option<ClrMethodCallDescription>>());
        }

        public static IEnumerable<IOption> Execute<T>(this OperationWorkflow workflow, T host, OperationArgParser parser = null)
        {
            var requested = Describe<T>(workflow);
            foreach (var i in requested.Where(i => i.IsNone()))
                yield return i;
            var available = requested.Where(i => i.Exists).Select(i => i.Require()).ToList();

            foreach (var invocation in available)
                yield return Execute(invocation, host,parser);
        }

        static Option<ClrMethodCallDescription> DescribeInvocation(this ClrInterfaceDescription i, OperationExecSpec spec)
                => i.DescribeInvocation(spec.OperationName, spec.Arguments.Select(x => (x.Key,x.Value)).ToArray());

        static ClrInterfaceDescription DescribeContract<T>()
            => ClrInterfaceDescription.Create<T>();

        static Option<ClrMethodDescription> DescribeOperation<T>(this OperationExecSpec execSpec)
            => DescribeContract<T>().DescribeOperation(execSpec.OperationName);
    }
}
