// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;

    using static minicore;

    public static class Zero<T>
    {
        public static T Value { get; }
            = default;
    }

    public static class One<T>
    {
        public static T Value { get; }
            = Increment<T>.Apply(Zero<T>.Value);

    }

}
