//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using SqlT.Core;
    using SqlT.Proxies.Z0;

    using Meta.Core;
    using Meta.Models;
    using Meta.Syntax;

    using static SqlSyntax;

    using static metacore;
    using static grammar;

    using sxc = contracts;

    partial class SqlGrammar
    {

        partial class Choices
        {                

            public static ChoiceGroup allow_snapshot_isolation
                => choices(ON | OFF);

            public static ChoiceGroup ansi_null_default
                => choices(ON | OFF);

            public static ChoiceGroup ansi_nulls
                => choices(ON | OFF);

            public static ChoiceGroup ansi_padding
                => choices(ON | OFF);

            public static ChoiceGroup ansi_warnings
                => choices(ON | OFF);

            public static ChoiceGroup arithabort
                => choices(ON | OFF);

            public static ChoiceGroup auto_close
                => choices(ON | OFF);

            public static ChoiceGroup auto_create_statistics
                => choices(ON | OFF);

            public static ChoiceGroup auto_update_statistics
                => choices(ON | OFF);

            public static ChoiceGroup auto_shrink
                => choices(ON | OFF);

            public static ChoiceGroup containment
                => choices(NONE | PARTIAL);

            public static ChoiceGroup compatibility_level
                => choices<CompatibilityLevel>();

            public static ChoiceGroup concat_null_yields_null
                => choices(ON | OFF);

            public static ChoiceGroup db_encryption
                => choices(ON | OFF);

            public static ChoiceGroup db_update
                => choices(READ_ONLY | READ_WRITE);

            public static ChoiceGroup db_user_access
                => choices(SINGLE_USER | RESTRICTED_USER | MULTI_USER);

            public static ChoiceGroup db_state
                => choices(ONLINE | OFFLINE | EMERGENCY);

            public static ChoiceGroup db_chaining
                => choices(ON | OFF);

            public static ChoiceGroup delayed_durability
                => choices(DISABLE | ALLOWED | FORCED);

            public static ChoiceGroup memory_optimized_elevate_to_snapshot
                => choices(ON | OFF);

            public static ChoiceGroup non_transacted_access
                => choices(OFF | READ_ONLY | FULL);

            public static ChoiceGroup nested_triggers
                => choices(ON | OFF);

            public static ChoiceGroup quoted_identifier
                => choices(ON | OFF);

            public static ChoiceGroup recursive_triggers
                => choices(ON | OFF);

            public static ChoiceGroup read_committed_snapshot
                => choices(ON | OFF);

            public static ChoiceGroup trustworthy
                => choices(ON | OFF);

            public static ChoiceGroup transform_noise_words
               => choices(ON | OFF);

            public static ChoiceGroup size_unit
                => choices(KB | MB | GB | TB);

            public static ChoiceGroup sql_collation_name
                => choices(SqlCollations.Value);

        }
    }

}