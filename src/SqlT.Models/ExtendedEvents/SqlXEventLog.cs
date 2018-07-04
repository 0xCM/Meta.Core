﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;



    public abstract class SqlXEventLog<L,T>
        where L : SqlXEventLog<L,T>
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