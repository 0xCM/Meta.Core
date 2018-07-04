//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Models;

    partial class TypeStructures
    {

        public abstract class Sequence<T, K> : ObjectStructure<T, SqlSequence, SqlSequenceName>, ISequence
            where T : Sequence<T, K>, new()
            where K : sxc.integer_type
        {
            protected Sequence()
            {
                
            }

            public virtual int? Cache { get; }

            public virtual long? StartWith { get; }

            public abstract K DataType { get; }

            public override SqlSequence CreateModel()
                => new SqlSequence(Name, new typeref(DataType, false));

            public override SqlSequenceName Name
                => new SqlSequenceName(SchemaName, GetType().Name);
        }
    }
}