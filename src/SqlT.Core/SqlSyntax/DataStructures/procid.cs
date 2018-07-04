//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using static metacore;
    using sxc = contracts;

    public struct procid : sxc.sqlid<int>
    {
        public static procid Specify(int value)
            => new procid(value);

        public static procid Parse(string text)
            => new procid(int.Parse(text));

        public static implicit operator procid(int Value)
            => Specify(Value);

        public int Value { get; }

        public procid(int Value)
        {
            this.Value = Value;
        }

        public override string ToString()
            => Value.ToString();
    }

}