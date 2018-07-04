//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;

    abstract class SqlObjectRuntime<T,H> : SqlElementRuntime<T,H>, ISqlObjectRuntime
        where T : SqlObjectRuntime<T, H>
        where H : ISqlObjectHandle
    {
        protected SqlObjectRuntime(IApplicationContext C, H Handle)
            : base(C, Handle)
        {

        }

        public Option<SqlBooleanValue> Exists()
            => Handle.Exists();
    }


}