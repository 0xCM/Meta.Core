//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

using static minicore;

public abstract class ApplicationService : ApplicationComponent, IApplicationService
{

    protected ApplicationService(IApplicationContext Context)
        : base(Context)
    {
        this.TargetEnvironment = Context.EnvironmentName;
    }

    protected ApplicationService(IApplicationContext Context, RuntimeEnvironment TargetEnvironment)
        : base(Context)
    {
        this.TargetEnvironment = TargetEnvironment;
    }


    public RuntimeEnvironment TargetEnvironment { get; }

    protected abstract ServiceDescriptor GetServiceDescriptor();

    ServiceDescriptor IApplicationService.ServiceDescriptor
        => GetServiceDescriptor();
}

public abstract class ApplicationService<S, I> : ApplicationService, IDisposable
    where S : ApplicationService<S, I>
{

    protected static readonly string ImplementationName =
        typeof(S).GetCustomAttribute<ApplicationServiceAttribute>()?.ImplementationName ?? DefaultImplementationName;

    protected static string OperationName([CallerMemberName] string name = null)
    {
        return $"{typeof(I).Name}/{name}";
    }

    protected static IAppMessage OperationNotImplemented([CallerMemberName] string name = null)
        => AppMessage.Warn($"The service operation {typeof(I).Name}/{name} has not been implemented");

    public static ServiceDescriptor ServiceDescriptor
        => new ServiceDescriptor(typeof(S), ImplementationName, typeof(I));

    protected override ServiceDescriptor GetServiceDescriptor()
        => ServiceDescriptor;

    protected I Self
        => cast<I>(this);


    protected Option<X> CompletedOperation<X>(Option<X> x)

    {
        x.OnNone(Notify).OnSome(result => x.OnMessage(Notify));
        return x;
    }

    protected ApplicationService()
        : base(ApplicationContext.Empty)
    { }

    protected ApplicationService(IApplicationContext Context)
        : base(Context)
    {
        
    }

    protected ApplicationService(IApplicationContext Context, RuntimeEnvironment TargetEnvironment)
        : base(Context, TargetEnvironment)
    {

    }


    protected virtual void Dispose()
    {

    }

    void IDisposable.Dispose()
        => Dispose();


}

public abstract class ApplicationService<S, I1, I2> : ApplicationService
    where S :  ApplicationService<S, I1, I2>
{


    protected override ServiceDescriptor GetServiceDescriptor()
        => ServiceDescriptor;

    public static ServiceDescriptor ServiceDescriptor
       => new ServiceDescriptor(typeof(S), DefaultImplementationName, typeof(I1), typeof(I2));

    protected ApplicationService(IApplicationContext Context)
        : base(Context)
    {

    }

    protected ApplicationService(IApplicationContext Context, RuntimeEnvironment TargetEnvironment)
        : base(Context, TargetEnvironment)
    {

    }

}

