//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Ultimate base class for application services
    /// </summary>
    public abstract class Service : ApplicationComponent, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> type
        /// </summary>
        /// <param name="context"></param>
        protected Service(IApplicationContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Should be overridden in subclasses whenever resources need to be released when the service terminates
        /// </summary>
        public virtual void Dispose()
        {

        }
    }


    /// <summary>
    /// Defines base class for service parametrized by the service contract
    /// </summary>
    /// <typeparam name="C">The contract type realized by the service</typeparam>
    /// <remarks>
    /// Several aspects are motivating the choice of parametrizing the service
    /// with its contract parameter. I'll mention one:
    /// Explicit interface implementation for service contracts is almost always preferable
    /// an implicit implementation. It is often the case though that the implementation
    /// of one contract membrer is dependent on another contract member. By chaining up
    /// the contract, derived types can simply access such dependencis through the 
    /// <see cref="Contract"/> field, precluding the need to cast this to the contract
    /// type and consequently reducing syntactic noise. The cast hapens only once: when
    /// the type is initialized
    /// </remarks>
    public abstract class Service<C> : Service
    {
        /// <summary>
        /// Contractg realization instance
        /// </summary>
        protected readonly C Contract;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{C}"/> type
        /// </summary>
        /// <param name="context">The context in which the service is executing</param>
        protected Service(IApplicationContext context)
            : base(context)
        {
            Contract = (C)(object)(this);

        }
    }

    /// <summary>
    /// Defines base class for service parametrized by the service contract and the configuration settings group
    /// </summary>
    /// <typeparam name="C">The contract type realized by the service</typeparam>
    /// <typeparam name="G">The setting group type</typeparam>
    public abstract class Service<C, G> : Service<C>
        where G : ProvidedConfiguration<G>
    {
        protected readonly G Settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{C,G}"/> type
        /// </summary>
        /// <param name="context">The context in which the service is executing</param>
        protected Service(IApplicationContext context)
            : base(context)
        {
            Settings = Settings<G>();

        }
    }

}