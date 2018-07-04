//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using V1 = SqlSyntax.left_join;
    using V2 = SqlSyntax.right_join;
    using V3 = SqlSyntax.full_join;
    using V4 = SqlSyntax.inner_join;
    using V5 = SqlSyntax.cross_join;
    using V6 = SqlSyntax.cross_apply;
    using V7 = SqlSyntax.outer_apply;

    using DU = SqlSyntax.join_type;

    partial class SqlSyntax
    {

        public sealed class join_type : du<V1, V2, V3, V4, V5, V6, V7>
        {
            public static implicit operator DU(V1 v)
                => new DU(v);

            public static implicit operator DU(V2 v)
                => new DU(v);

            public static implicit operator DU(V3 v)
                => new DU(v);

            public static implicit operator DU(V4 v)
                => new DU(v);

            public static implicit operator DU(V5 v)
                => new DU(v);

            public static implicit operator DU(V6 v)
                => new DU(v);

            public static implicit operator DU(V7 v)
                => new DU(v);

            public join_type(V1 v)
                : base(v) { }

            public join_type(V2 v)
                : base(v) { }

            public join_type(V3 v)
                : base(v) { }

            public join_type(V4 v)
                : base(v) { }

            public join_type(V5 v)
                : base(v) { }

            public join_type(V6 v)
                : base(v) { }

            public join_type(V7 v)
                : base(v) { }

        }
    }


}