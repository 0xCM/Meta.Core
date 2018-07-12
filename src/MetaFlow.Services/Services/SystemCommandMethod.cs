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

    using Meta.Core;

    using static metacore;

    using MetaFlow.Core;
    using SqlT.Core;
    using MetaFlow.WF;

    public class SystemCommandMethod : ILink<SystemCommandUri,MethodInfo>
    {

        public static IEnumerable<SystemCommandMethod> Dicover(Type HostType)
            => from m in HostType.GetPublicMethods(MemberInstanceType.Instance)
               let parameters = m.GetParameters()
               where parameters.Length == 1
               let messageType = parameters[0].ParameterType
               where messageType.Realizes<ISystemCommand>()
               let uri = SystemCommandUri.ReferenceUri(messageType)
               select new SystemCommandMethod(ClrClass.Get(messageType), uri, m);


        public SystemCommandMethod(ClrClass CommandType, SystemCommandUri ReferenceUri, MethodInfo Method)
        {
            this.CommandType = CommandType;
            this.ReferenceUri = ReferenceUri;
            this.Method = Method;
        }


        public ClrClass CommandType { get; }

        public SystemCommandUri ReferenceUri { get; }

        public MethodInfo Method { get; }

        SystemCommandUri ILink<SystemCommandUri, MethodInfo>.Source
            => ReferenceUri;

        MethodInfo ILink<SystemCommandUri, MethodInfo>.Target
            => Method;

        LinkIdentifier ILink.Name
            => link(ReferenceUri, Method).Name;

        public override string ToString()
            => $"{ReferenceUri} => {Method.Uri()}";
    }

}