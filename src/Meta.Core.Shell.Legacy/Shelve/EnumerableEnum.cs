//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using Meta.Core;

using static metacore;

public static class EnumerableEnum
{

    
    public static Option<E> TryParse<T, E>(string text) 
        where T : EnumerableEnum<T, E>, new()
            => parseEnum<E>(text);
}


public class EnumerableEnum<T,E> : SemanticValue<T, E>, IEquatable<T>, IComparable<T>
    where T : EnumerableEnum<T,E>, new()


{

    public static Option<E> TryParse(string Text)
        => EnumerableEnum.TryParse<T, E>(Text);


    public static implicit operator E(EnumerableEnum<T,E> x)
        => x.Value;
    
    
    protected EnumerableEnum()
    {

    }

    protected EnumerableEnum(E Value)
        : base(Value)
    {

    }

    public IEnumerable<ClrEnumLiteralInfo> Literals
        => ClrEnumInfo.FromType(typeof(E)).Literals;

    public override bool Equals(T other)
        => Value.Equals(other.Value);

    public int CompareTo(T other)
        => cast<Enum>(Value).CompareTo(other.Value);

}
