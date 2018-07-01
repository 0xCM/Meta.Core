//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class SelectionFacet
    {

        protected SelectionFacet(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; }

    }

    public abstract class SelectionFacet<F,V> : SelectionFacet
        where F : SelectionFacet<F,V>
    {
        protected SelectionFacet(string Name, V Value)
            : base(Name)
        {
            this.Value = Value;
        }

        public V Value { get; }

        public override string ToString()
            => $"{Name}({Value})";


    }

    public class SelectionFacets
    {
        public static DistinctFacet Distinct() 
            =>  new DistinctFacet();

        public static InversionFacet Invert()
            => new InversionFacet();

        public static TopFacet Top(int Count) 
            => new TopFacet(Count);
    }
}
