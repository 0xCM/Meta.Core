//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Specifies a client->supplier dependency relationship
    /// </summary>
    /// <typeparam name="C">The client type</typeparam>
    /// <typeparam name="S">The supplier type</typeparam>
    public abstract class Dependency<C, S> : IDependency<C, S>, IEquatable<Dependency<C,S>>
    {
        protected Dependency(C Client, S Supplier)
        {
            this.Client = Client;
            this.Supplier = Supplier;
        }

        /// <summary>
        /// The dependency client
        /// </summary>
        public C Client { get; }

        /// <summary>
        /// The dependency supplier
        /// </summary>
        public S Supplier { get; }

        object IDependency.Client
            => Client;

        object IDependency.Supplier
            => Supplier;

        /// <summary>
        /// Adjudicates dependency equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Dependency<C, S> other)
            => isNull(other) ? false :
                   all(object.Equals(this.Client, other.Client),
                object.Equals(this.Supplier, other.Supplier));

        public override string ToString()
            => $"{Client}-->{Supplier}";

        public override int GetHashCode()
            => Client.GetHashCode() ^ 
                    Supplier.GetHashCode();

        public override bool Equals(object obj)
            => Equals(obj as Dependency<C, S>);
    }

    public sealed class Dependency : Dependency<object,object>
    {
        public Dependency(object Client, object Supplier)
            : base(Client, Supplier)
        {

        }
    }

}