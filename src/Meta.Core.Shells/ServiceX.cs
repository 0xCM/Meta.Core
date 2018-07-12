using System;
using static metacore;

public static class ServiceX
{
    public static Lazy<S> LazyService<S>(this IApplicationContext C)
        => defer(() => C.Service<S>());

    /// <summary>
    /// Obtains a reference to the assembly registration service
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <returns></returns>
    public static IAssemblyRegistrar AssemblyRegistrar(this IApplicationContext C)
        => C.Service<IAssemblyRegistrar>();

    public static IMutableContext WithTransientBroker(this IMutableContext C, Action<IAppMessage> observer)
    {
        C.InjectService<IMessageBroker>(TransientMessageBroker.Create(observer));
        return C;
    }


}