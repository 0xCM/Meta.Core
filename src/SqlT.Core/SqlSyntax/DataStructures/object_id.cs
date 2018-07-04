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

    public struct object_id : sxc.sqlid<int>
    {
        public static object_id Specify(int value)
            => new object_id(value);

        public static object_id Parse(string text)
            => new object_id(int.Parse(text));

        public static implicit operator object_id(int Value)
            => Specify(Value);

        public int Value { get; }

        public object_id(int Value)
        {
            this.Value = Value;
        }

        public override string ToString()
            => Value.ToString();
    }

}