//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;    
    using System.Collections;
    using System.Collections.Generic;

    public interface ISeqTypeCtor<X> : ITypeCtor<IEnumerable<X>, X, Seq<X>> 
    {

    }     

    /// <summary>
    /// Seq constructor
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    public readonly struct SeqTypeCtor<X> : ISeqTypeCtor<X>
    {
        public static readonly SeqTypeCtor<X> instance = default;

        public Func<IEnumerable<X>, Seq<X>> ctor()
            => source => Seq<X>.Factory(source);
    }
}