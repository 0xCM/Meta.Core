//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    

    class SqlTableRuntime : SqlObjectRuntime<SqlTableRuntime, ISqlTableHandle>, ISqlTableRuntime
    {

        public SqlTableRuntime(IApplicationContext C, ISqlTableHandle Handle)
            : base(C, Handle)
        {

        }

        public SqlTableName Name
            => Handle.ElementName;

        public Option<SqlTable> CreateIfMissing<T>()
            where T : ISqlTabularProxy, new()
            => Handle.CreateIfMissing<T>(Name);

        Option<int> ISqlTableRuntime.DropIfExists()
            => Handle.DropIfExists();

        Option<int> ISqlTableRuntime.CopyInto(SqlTableName target)
            => Handle.SelectInto(target);

        Option<int> ISqlTableRuntime.Count()
            => Handle.Count();

        public Option<int> Count(string @where)
            => Handle.Count(@where).TryMapValue(x => x);
               
        Option <int> ISqlTableRuntime.Delete()
            => Handle.Delete();

        Option<int> ISqlTableRuntime.Truncate()
            => Handle.TruncateIfExists();

        public Option<SqlDataFrame> Select(params SqlColumnName[] names)
            => Handle.Select(names);

        public ScalarResult<T> Max<T>(SqlColumnName name)            
                => Handle.Max<T>(name);

        public ScalarResult<T> Min<T>(SqlColumnName name)            
                => Handle.Min<T>(name);

        public ISqlIndexRuntime Index(SqlIndexName name)
            => SqlRuntime.Index(Handle.Index(name));

        public ScalarResult<int> DistinctCount(SqlColumnName name)
            => Handle.CountDistinct(name);

        public IEnumerable<T> Distinct<T>(SqlColumnName name)
            => Handle.Distinct<T>(name);

        public IEnumerable<Record<C0, C1>> Distinct<C0, C1>(SqlColumnName c0, SqlColumnName c1)
            => Handle.Distinct<C0,C1>(c0, c1);

    }
}