//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using static metacore;


    public sealed class ElementDescriptor
    {

        public ElementDescriptor(string Name, string Label, int? Line = null)
        {
            this.Name = Name;
            this.Label = Label;
            this.Line = Line ?? 0;
        }


        public string Name { get; }

        public string Label { get; }

        public int Line { get; }

        public override string ToString()
            => concat(
                Line.ToString().PadLeft(4, '0'), 
                Name, 
                isBlank(Label) ? string.Empty : bracket(Label)
                );

    }



}