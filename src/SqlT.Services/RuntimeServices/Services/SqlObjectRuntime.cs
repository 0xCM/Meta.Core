//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using SqlT.Core;


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