//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    using CID = ComponentIdentifier;

    /// <summary>
    /// Represents a collection of dependencies from one component to a set of components
    /// </summary>
    public abstract class ComponentDependencySet<B> : MutableSet<B, CID>
        where B : MutableSet<B, CID>
    {

        public ComponentDependencySet(CID Client, params CID[] Suppliers)
            : base(Suppliers)
        {
            this.Client = Client;
        }

        public ComponentDependencySet(CID Client, IEnumerable<CID> Suppliers)
            : base(Suppliers)
        {

            this.Client = Client;
        }

        public CID Client { get; }

        public override string ToString()
            => concat(Client, Symbol.arrowR, lbrace(), string.Join(",", this), rbrace());
    }

}