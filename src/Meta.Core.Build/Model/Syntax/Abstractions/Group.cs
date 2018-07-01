//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public abstract class Group<G> : ProjectElement<G>
        where G : Group<G>
    {


        protected Group(string Name, string Label, string Condition)
            : base(Name, Label, Condition)
        {

        }        
    }


    public abstract class Group<G,M> : Group<G>
        where G : Group<G,M>
    {


        protected Group(string ElementName, IEnumerable<M> Members, string Label, string Condition)
            : base(ElementName, Label, Condition)
        {
            this.Members = Members ?? stream<M>();
        }

        public virtual IEnumerable<M> Members { get; }

        protected abstract string FormatMember(M member);            

        protected override string FormatContent()
            => string.Join(eol(), Members.Select(FormatMember).ToArray());


    }

}