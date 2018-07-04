//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using static metacore;
    using sxc = SqlT.Syntax.contracts;
    using kwt = SqlT.Syntax.SqlKeywordTypes;

    public class SqlSequenceBuilder : SqlModelBuilder<SqlSequence>
    {
        static SqlSequence BuildSequence
            (
                SqlSequenceName name,
                sxc.ISqlType dataType,
                object initialValue = null,
                object increment = null,
                object maxValue = null,
                object cacheSize = null
            ) =>
            new SqlSequence
            (
                SequenceName: name,
                SequenceDataType: dataType.Reference(false),
                InitialValue: initialValue == null ? "1" : toString(initialValue),
                Increment: increment == null ? "1" : toString(increment),
                MaxValue: maxValue == null ? null : toString(maxValue),
                CacheSize: cacheSize == null ? "10" : toString(cacheSize)
            );

        public static SqlSequence CreateIntSequence(SqlSequenceName name, int initialValue = 1, int increment = 1, int cacheSize = 10)
            => BuildSequence(name, SqlNativeTypes.sqlint, initialValue, increment, null, cacheSize);

        public static SqlSequence CreateBigIntSequence(SqlSequenceName name, long initialValue = 1, long increment = 1, int cacheSize = 10)
            => BuildSequence(name, SqlNativeTypes.bigint, initialValue, increment, null, cacheSize);



        SqlSequenceDescription settings;
        internal SqlSequenceBuilder(SqlSequenceDescription settings)
        {
            this.settings = settings;
        }

        public override SqlSequence Complete()
        {
            throw new NotImplementedException();
        }
    }

    public class SqlSequenceBuilder<T> : SqlModelBuilder<SqlSequence>
        where T : IComparable
    {
        SqlSequenceDescription<T> settings;

        internal SqlSequenceBuilder(SqlSequenceDescription<T> settings)
        {
            this.settings = settings;
        }

        public override SqlSequence Complete()
            => new SqlSequence
                (
                    SequenceName: settings.SequenceName,
                    SequenceDataType: settings.ItemType.MapToSqlType().Reference(),
                    InitialValue: settings.InitialValue.MapValueOrDefault(x => x.ToString()),
                   Increment: settings.Increment.MapValueOrDefault(x => x.ToString()),
                   MaxValue: settings.MaxValue.MapValueOrDefault(x => x.ToString()),
                   CacheSize: settings.CacheSize.MapValueOrDefault(x => x.ToString())
                   );
    }

}
