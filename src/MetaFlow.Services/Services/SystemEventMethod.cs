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
    using System.Diagnostics;

    using Meta.Core;

    using static metacore;

    using SqlT.Core;
    using MetaFlow.WF;

    public class SystemEventMethod : ILink<SystemEventUri,MethodInfo>
    {

        public static IEnumerable<SystemEventMethod> Dicover(Type HostType)
            => from m in HostType.GetPublicMethods(MemberInstanceType.Instance)
               let parameters = m.GetParameters()
               where parameters.Length == 1
               let messageType = parameters[0].ParameterType
               where messageType.Realizes<ISystemEvent>()
               let uri = SystemEventUri.ReferenceUri(messageType)
               select new SystemEventMethod(ClrClass.Get(messageType), uri, m);


        public SystemEventMethod(ClrClass EventType, SystemEventUri ReferenceUri, MethodInfo Method)
        {
            this.EventType = EventType;
            this.ReferenceUri = ReferenceUri;
            this.Method = Method;
        }


        public ClrClass EventType { get; }

        public SystemEventUri ReferenceUri { get; }

        public MethodInfo Method { get; }

        SystemEventUri ILink<SystemEventUri, MethodInfo>.Source
            => ReferenceUri;

        MethodInfo ILink<SystemEventUri, MethodInfo>.Target
            => Method;

        LinkIdentifier ILink.Name
            => link(ReferenceUri, Method).Name;

        public override string ToString()
            => $"{ReferenceUri} => {Method.Uri()}";

    }


}