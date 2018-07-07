//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    public abstract class SqlXEventLog<L, T>
        where L : SqlXEventLog<L, T>
        where T : SqlXEventTarget<T>
    {

        protected SqlXEventLog(T Target)
        {
            this.Target = Target;
        }

        public T Target { get; }

        public override string ToString()
            => Target.ToString();
    }
}