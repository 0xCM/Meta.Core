//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using N = SystemNode;

    public abstract class SqlChannel<T> : LinkedComponent, ISqlChannel<T>
       where T : ISqlClientBroker
    {

        protected SqlChannel(ILinkedContext C, T Source, T Target)
            : base(C)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public T Source { get; }

        public T Target { get; }
       

        public LinkIdentifier Name
            => new Link<T>(Source, Target).Name;

        public override string ToString()
            => Name;
    }




}