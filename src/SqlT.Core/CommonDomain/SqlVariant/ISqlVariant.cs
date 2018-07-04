//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public interface ISqlVariant
    {
        object Value { get; }

        SqlVariantKind VariantKind { get; }
    }

    public interface ISqlVariant<T> : ISqlVariant
    {
        new T Value { get; }
    }

    public interface ISqlVariant<T, V> : ISqlVariant<V>
        where T : ISqlVariant<T, V>
    {

    }

}