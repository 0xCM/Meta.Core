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
    using SqlT.Core;
    using Meta.Syntax;

    using static SqlSyntax;

    using static metacore;
    using static grammar;
    using static SqlGrammar.Choices;

    partial class SqlGrammar
    {
        partial class Statements
        {
            partial class Alter
            {
                public static class Database
                {

                    public static SyntaxRule db_encryption_option
                        => pair(ENCRYPTION, db_encryption);

                    public static SyntaxRule db_state_option
                        => db_state;

                    public static SyntaxRule db_update_option
                        => db_update;

                    public static SyntaxRule db_user_access_option
                        => db_user_access;

                    public static SyntaxRule termination
                        => maybe(
                            ROLLBACK + AFTER + integer() + maybe(SECONDS)
                          | ROLLBACK + IMMEDIATE
                          | NOWAIT
                            );

                    public static SyntaxRule auto_option
                        => choices(
                              auto_option
                            | auto_create_statistics
                            | auto_shrink
                            | auto_update_statistics
                            );

                    public static SyntaxRule service_broker_option
                        => define(
                              ENABLE_BROKER 
                            | DISABLE_BROKER 
                            | NEW_BROKER 
                            | ERROR_BROKER_CONVERSATIONS 
                            | HONOR_BROKER_PRIORITY + group(ON | OFF)
                            );

                    public static SyntaxRule automatic_tuning_option
                        => define(AUTOMATIC_TUNING + paren(toggle(FORCE_LAST_GOOD_PLAN)));

                    public static SyntaxRule change_tracking_option
                        => rule();

                    public static SyntaxRule containment_option
                        => define(assign(CONTAINMENT, containment));

                    public static SyntaxRule cursor_option
                        => rule();

                    public static SyntaxRule snapshot_option
                        => pair(ALLOW_SNAPSHOT_ISOLATION, allow_snapshot_isolation)
                        | pair(READ_COMMITTED_SNAPSHOT, read_committed_snapshot)
                        | pair(MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT, memory_optimized_elevate_to_snapshot);


                    public static SyntaxRule sql_option
                        => pair(ANSI_NULL_DEFAULT, ansi_null_default)
                        | pair(ANSI_NULLS, ansi_nulls)
                        | pair(ANSI_PADDING, ansi_padding)
                        | pair(ANSI_WARNINGS, ansi_warnings)
                        | pair(ARITHABORT, arithabort)
                        | pair(COMPATABILITY_LEVEL, compatibility_level)
                        | pair(CONCAT_NULL_YIELDS_NULL, concat_null_yields_null)
                        | pair(QUOTED_IDENTIFIER, quoted_identifier)
                        | pair(RECURSIVE_TRIGGERS, recursive_triggers)
                        ;

                    public static SyntaxRule target_recovery_time
                        => integerU();

                    public static SyntaxRule target_recovery_time_option
                        => assign(TARGET_RECOVERY_TIME, 
                            target_recovery_time + group(SECONDS | MINUTES));

                    public static SyntaxRule database_mirroring_option
                        => rule();

                    public static SyntaxRule date_correlation_optimization_option
                        => rule();

                    public static SyntaxRule delayed_durability_option
                        => define(assign(DELAYED_DURABILITY, delayed_durability));


                    public static SyntaxRule external_access_option
                        => rule();

                    public static SyntaxRule filestream_option
                        => FILESTREAM + assign(
                            NON_TRANSACTED_ACCESS,
                                group(                                  
                                 non_transacted_access
                                | assign(DIRECTORY_NAME, directory_name)
                                ));

                    public static SyntaxRule optionspec
                        => define(
                          auto_option
                        | automatic_tuning_option
                        | change_tracking_option
                        | containment_option
                        | cursor_option
                        | database_mirroring_option
                        | date_correlation_optimization_option
                        | db_encryption_option
                        | db_state_option
                        | db_update_option
                        | db_user_access
                        | delayed_durability_option
                        | external_access_option
                        | filestream_option
                        | service_broker_option
                        | snapshot_option
                        | sql_option
                        | target_recovery_time_option
                        | termination

                        );


                    public static SyntaxRule alter_datatabase_set()
                        => define(
                            ALTER + DATABASE + group(database_name | CURRENT)
                          + SET
                          + group(+optionspec + maybe(WITH + termination))
                            );
                }
            }
        }
    }
}