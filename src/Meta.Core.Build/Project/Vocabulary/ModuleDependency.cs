//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;

    using static metacore;

    using CID = ComponentIdentifier;
    using CD = ModuleDependency;

    /// <summary>
    /// Represents a (directed) dependency from one component to another
    /// </summary>
    public sealed class ModuleDependency  : IEquatable<CD>
    {
        public static implicit operator CD((CID Client, CID Supplier) Relation)
            => new CD(Relation);

        public static implicit operator (CID Client, CID Supplier)(CD cd)
            => (cd.Client,cd.Supplier);

        public ModuleDependency((CID Client, CID Supplier) Relation)
        {
            this.Client = Client;
            this.Supplier = Supplier;
        }


        public ModuleDependency(CID Client, CID Supplier)
        {
            this.Client = Client;
            this.Supplier = Supplier;

        }

        public CID Client { get; }

        public CID Supplier { get; }

        public bool Equals(CD other)
            => Client == other.Client
            && Supplier == other.Supplier;

        public override string ToString()
            => concat(Client, Symbol.arrowR, Supplier);

        public override int GetHashCode()
            => ToString().GetHashCode();

    }



}