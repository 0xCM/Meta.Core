//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;
    using static ApplicationMessage;

    public interface IOperationProvider
    {

        Option<object> TryInvoke(string descriptor);

        NodeLink Link { get; }
    }

    public abstract class OperationProvider : LinkedComponent, IOperationProvider
    {
           protected OperationProvider(ILinkedContext C)
                : base(C)
        {
        }

        protected virtual Option<object> ParseArgValue(ClrMethodParameter parameter, string argText)
            => metacore.try_parse(parameter.ParameterType, argText);

        public Option<object> TryInvoke(string descriptor)
        {
            try
            {
                var opName = ifBlank(descriptor, string.Empty).LeftOf('(');
                if (isBlank(opName))
                    return none<object>(Error("Name of operation could not be determined"));

                var args = from m in descriptor.TryGetFirstIndexOf('(')
                             from n in descriptor.TryGetLastIndexOf(')')
                             select descriptor.Substring(m + 1, n - m - 1).Split(',');
                if (!args)
                    return none<object>(Error("Argument list could not be determined"));

                var stringArgs = args.Require();

                var candidates = (from m in ClrClass.Get(GetType()).PublicInstanceMethods
                                 where m.Name == opName
                                 select m).ToList();

                if (candidates.Count == 0)
                    return none<object>(Error($"Method {opName} not found"));

                if (candidates.Count > 1)
                    return none<object>(Error($"Method overloads are not supported"));

                var method = candidates[0];
                var methodParms = method.Parameters.ToList();
                var j = Math.Min(stringArgs.Length, methodParms.Count);
                var argValues = new object[j];
                for(int i=0; i< j; i++)
                {
                    var param = methodParms[i];
                    var stringArg = stringArgs[i];
                    var argValue = ParseArgValue(param, stringArg);
                    if (!argValue)
                        return argValue;
                    else
                        argValues[i] = argValue.Require();                    
                }
                return method.Invoke(argValues);                                                                               
            }
            catch(Exception e)
            {

                return none<object>(e);
            }
        }
    }

    public abstract class SysOpComponent<S> : OperationProvider
        where S : SysOpComponent<S>
    {
        protected SysOpComponent(ILinkedContext C)
             : base(C)
        {

        }
    }

}
