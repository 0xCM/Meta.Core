//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    public abstract class XsdTypeInfo
    {
        public abstract string Name { get; }
        public override string ToString()
            => Name;
    }

    public abstract class XsdTypeInfo<T> : XsdTypeInfo
        where T : XsdTypeInfo<T>
    {

    }



}