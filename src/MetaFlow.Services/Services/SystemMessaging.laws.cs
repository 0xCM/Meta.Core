//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;
    using static metacore;

    using MetaFlow.WF;
    using SqlT.Core;


    public interface ISystemMessaging : INodeService
    {
        ISystemEventCapture<TBody> RaiseStatus<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new();

        ISystemEventCapture<TBody> RaiseWarning<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new();

        ISystemEventCapture<TBody> RaiseError<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new();

        ISystemEventCapture<TBody> RaisePaired<TBody>(ISystemEventCapture Antecedent, TBody Body)
            where TBody : class, ISystemEvent, new();

        Option<SystemTask> SubmitCommand<K>(K Command, CorrelationToken? CT = null)
            where K : class, ISystemCommand, ISqlTableTypeProxy, new()
            ;

    }



}