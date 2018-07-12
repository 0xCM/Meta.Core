//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    using MetaFlow.WF;
    using SqlT.Core;
  
    public abstract class SystemTaskHandler<H> : PlatformService<H, ISystemTaskHandler>, ISystemTaskHandler
        where H : SystemTaskHandler<H>
    {
        

        IReadOnlyDictionary<SystemCommandUri, SystemCommandMethod> CommandMethods { get; }

        protected SystemTaskHandler(INodeContext C)
            : base(C)
        {

            CommandMethods = dict(from m in SystemCommandMethod.Dicover(GetType())
                                  select (m.ReferenceUri, m));
        }


        Option<SystemCommandMethod> CommandMethod(string uri)
            => CommandMethods.TryFind(SystemCommandUri.Parse(uri).ToReferenceUri());

        Option<ISystemCommand> CommandBody(SystemCommandMethod method, string  bodyText)
        {
            try
            {
                return some(Serializer.ObjectFromJson(method.CommandType, bodyText) as ISystemCommand);
            }
            catch(Exception e)
            {
                return none<ISystemCommand>(e);
            }

        }
               
        Option<object> InvokeCommandMethod(SystemCommandMethod cm, ISystemCommand command)
        {
            try
            {
                return cm.Method.Invoke(this, array(command));
            }
            catch(Exception e)
            {
                return none<object>(e);
            }
        }

        Option<SystemTaskResult> ExecuteTask(ISystemTaskDefinition task)
            => from cm in CommandMethod(task.CommandUri)
               from body in CommandBody(cm, task.CommandBody)
               from invocation in InvokeCommandMethod(cm, body)
               select task.Adjudicate(invocation);


        Option<SystemTaskResult> ExecuteTask(ISystemTask task)
            => from cm in CommandMethod(task.CommandUri)
               from body in CommandBody(cm, task.CommandBody)
               from invocation in InvokeCommandMethod(cm, body)               
               select task.Adjudicate(invocation);

        IEnumerable<SystemCommandUri> ISystemTaskHandler.SupportedCommands
            => CommandMethods.Keys;

        ISystemTaskResult ISystemTaskHandler.ExecuteTask(ISystemTaskDefinition task)
            => ExecuteTask(task).MapValueOrElse(x => x, reason => task.DeclareFailure(reason));

        ISystemTaskResult ISystemTaskHandler.ExecuteTask(ISystemTask task)
            =>ExecuteTask(task).MapValueOrElse(x => x, reason => task.DeclareFailure(reason));

    }
}