//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;

    partial class SqlSyntax
    {

        public interface alter_index_choice_item : IModel
        {
            IKeyword choice_type { get; }
        }

        public sealed class alter_index_choice
            : cdu<alter_index_choice_item,
                    alter_index_rebuild,
                    alter_index_disable,
                    alter_index_reorganize,
                    alter_index_set,
                    alter_index_resume,
                    alter_index_pause,
                    alter_index_abort
            >
        {

            public static implicit operator alter_index_choice(kwt.DISABLE DISABLE)
                => new alter_index_choice(DISABLE);

            public static implicit operator alter_index_choice(kwt.REBUILD REBUILD)
                => new alter_index_choice(REBUILD);

            public alter_index_choice(alter_index_rebuild x)
                : base(x)
            { }

            public alter_index_choice(alter_index_disable x)
                : base(x)
            { }

            public alter_index_choice(alter_index_reorganize x)
                : base(x)
            { }

            public alter_index_choice(alter_index_set x)
                : base(x)
            { }

            public alter_index_choice(alter_index_resume x)
                : base(x)
            { }

            public alter_index_choice(alter_index_pause x)
                : base(x)
            { }

            public alter_index_choice(alter_index_abort x)
                : base(x)
            { }

        }


    }

}