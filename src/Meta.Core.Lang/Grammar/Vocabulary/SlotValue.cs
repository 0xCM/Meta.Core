//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;


    /// <summary>
    /// Defines a value for a slot in a syntax model
    /// </summary>
    public struct SlotValue<V>
    {
        public SlotValue(Slot Selection, V Value)
        {
            this.Selection = Selection;
            this.Value = Value;
        }

        public Slot Selection { get; }

        public V Value { get; }

        public override string ToString()
            => $"{Selection} = {Value}";
    }


    /// <summary>
    /// Defines a value for a slot in a syntax model
    /// </summary>
    public struct SlotValue
    {
        public SlotValue(Slot Selection, string Value)
        {
            this.Selection = Selection;
            this.Value = Value;
        }

        public Slot Selection { get; }

        public string Value { get; }

        public override string ToString()
            => $"{Selection} = {Value}";
    }



}