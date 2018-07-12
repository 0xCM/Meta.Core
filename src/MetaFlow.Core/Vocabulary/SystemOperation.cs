//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using Meta.Core;

    using static metacore;

    public sealed class SystemOperation
    {

        static IConversionSuite Parsers
            = PrimitiveParsers.Projectors();


        public SystemOperation(SystemIdentifier PlatformSystem, ShellCommandDescriptor Descriptor)
        {
            this.PlatformSystem = PlatformSystem;
            this.HostType = Descriptor.HostType;
            this.Description = Descriptor.Description;
            this.DefiningMethod = Descriptor.DefiningMethod;
            this.Identifier = Descriptor.Identifier;
            this.LocalName = Descriptor.LocalName;
        }

        public SystemIdentifier PlatformSystem { get; }

        public Type HostType { get; }

        public string Description { get; }

        public ClrMethod DefiningMethod { get; }       

        public CommandName LocalName { get; }

        public SystemUri Identifier { get; }

        public bool IsDeclaredByHost
            => DefiningMethod.DeclaringType.ReflectedElement == HostType;

        public string HostTypeName
            => HostType.Name;


        public SystemOperationIdentifier Identify(SystemNodeIdentifier NodeId)
            => new SystemOperationIdentifier(NodeId, this);


        public object Invoke(ILinkedComponent Host, IEnumerable<string> args)
        {
            var _args = ParseArguments(args).Select(x => x.Value).ToArray();            
            var result = DefiningMethod.InvokeOnHost(Host, _args);
            return result;

        }

        public object Invoke(ILinkedComponent Host, IEnumerable<object> args)
        {
            var _args = ParseArguments(args).Select(x => x.Value).ToArray();
            var result = DefiningMethod.InvokeOnHost(Host, _args);
            return result;
        }


        public IEnumerable<NamedValue> ParseArguments(IEnumerable<object> args)
        {

            var parameters = DefiningMethod.Parameters.ToReadOnlyList();
            var arguments = args.ToReadOnlyList();
            var maxidx = Math.Max(parameters.Count, arguments.Count);
            for (var i = 0; i < maxidx; i++)
            {
                var paramName = parameters[i].Name;
                var paramType = parameters[i].ParameterType;

                var inputArg = arguments[i];
                var argValue =
                    (isNotNull(inputArg) && inputArg.GetType() != paramType)
                    ? Parsers.Convert(paramType, inputArg)
                    : inputArg;

                yield return new NamedValue(paramName, argValue);
            }
        }

        public IEnumerable<NamedValue> ParseArguments(IEnumerable<string> args)
        {

            var parameters = DefiningMethod.Parameters.ToReadOnlyList();
            var arguments = args.ToReadOnlyList();
            var maxidx = Math.Max(parameters.Count, arguments.Count);
            for (var i = 0; i < maxidx; i++)
            {
                var paramName = parameters[i].Name;
                var paramType = parameters[i].ParameterType;
                var inputArg = arguments[i];
                yield return new NamedValue(paramName, Parsers.Convert(paramType, inputArg));
            }
        }


        public override string ToString()
            =>  $"{PlatformSystem}/{HostType.Name}/{LocalName}";


    }

}