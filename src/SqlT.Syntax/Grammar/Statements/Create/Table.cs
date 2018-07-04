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
    using ops = SqlSyntax.sqlops;
    using sx = SqlSyntax;

    using static metacore;
    using static grammar;

    partial class SqlGrammar
    {
        partial class Statements
        {
            partial class Create
            {

                public static class Table
                {

                    public static SyntaxRule @default
                        => slot(enquote("default"));

                    public static SyntaxRule filegroup
                        => token();

                    public static SyntaxRule partition_scheme_name
                        => token();

                    public static SyntaxRule partition_column_name
                        => token();

                    public static SyntaxRule system_start_time_column_name
                        => token();

                    public static SyntaxRule system_end_time_column_name
                        => token();

                    public static SyntaxRule mask_function
                        => stringLiteral();

                    public static SyntaxRule constant_expression
                        => slot();

                    public static SyntaxRule column_constraint
                        => rule();

                    public static SyntaxRule column_index
                        => rule();

                    public static SyntaxRule seed
                        => integer();

                    public static SyntaxRule increment
                        => integer();

                    public static SyntaxRule key_name
                        => token();
                    public static SyntaxRule data_type
                        => rule();

                    public static SyntaxRule column_definition
                        => column_name + data_type
                        + maybe(FILESTREAM)
                        + maybe(COLLATE + collation_name)
                        + maybe(SPARSE)
                        + maybe(MASKED + WITH + paren(assign(FUNCTION, mask_function)))
                        + maybe(CONSTRAINT + constraint_name + maybe(DEFAULT + constant_expression))
                        + maybe(IDENTITY + maybe((seed, increment)))
                        + maybe(not_for_replication)
                        + maybe(GENERATED + ALWAYS + AS + ROW + group(START | END) + maybe(HIDDEN))
                        + maybe(NULL | (NOT + NULL))
                        + maybe(ROWGUIDCOL)
                        + maybe(ENCRYPTED + WITH +
                                    (
                                        assign(COLUMN_ENCRYPTION_KEY, key_name),
                                        assign(ENCRYPTION_TYPE, group(DETERMINISTIC | RANDOMIZED)),
                                        assign(ALGORITHM, stringLiteral("AEAD_AES_256_CBC_HMAC_SHA_256"))
                                    )
                                )
                        + maybe(+column_constraint)
                        + maybe(column_index);


                    public static SyntaxRule computed_column_definition
                        => rule();

                    public static SyntaxRule column_set_definition
                        => rule();

                    public static SyntaxRule index_option
                        => rule();

                    public static SyntaxRule fillfactor
                        => integerU();

                    public static SyntaxRule referenced_table_name
                        => object_name();

                    public static SyntaxRule logical_expression
                        => rule();

                    public static SyntaxRule partition_number_expression
                        => rule();

                    public static SyntaxRule ref_column
                        => token();

                    public static SyntaxRule schema_name
                        => token();

                    public static SyntaxRule history_table_name
                        => token();

                    public static SyntaxRule column
                        => token();

                    public static SyntaxRule table_constraint
                        => choices(maybe(CONSTRAINT + constraint_name)
                            + group(
                                group(PRIMARY + KEY)
                              + maybe(CLUSTERED | NONCLUSTERED)
                              + paren(+(maybe(ASC | DESC) + column_name))
                              + maybe(
                                  WITH + assign(FILLFACTOR, fillfactor)
                                | WITH + paren(+index_option)
                              + maybe(ON +
                                  group(partition_scheme_name + paren(partition_column_name))
                                | filegroup
                                | @default
                                  )
                             | FOREIGN + KEY + paren(+column)
                                 + REFERENCES + referenced_table_name + maybe(+ref_column))
                                 + maybe(ON + DELETE + group(NO + ACTION | CASCADE | SET + NULL | SET + DEFAULT))
                                 + maybe(ON + UPDATE + group(NO + ACTION | CASCADE | SET + NULL | SET + DEFAULT))
                                 + maybe(not_for_replication)
                                 )
                             | CHECK + maybe(not_for_replication) + paren(logical_expression)
                             );

                    public static SyntaxRule table_index
                        => rule();

                    public static SyntaxRule table_stretch_options
                        => rule();

                    public static SyntaxRule range
                        => rule();

                    public static SyntaxRule table_option
                        => define(
                            maybe(assign(DATA_COMPRESSION, oneOf(NONE | ROW | PAGE))
                                + +maybe(ON + PARTITIONS + paren(group(partition_number_expression | range))))
                        +   maybe(assign(FILETABLE_DIRECTORY, directory_name))
                        +   maybe(assign(FILETABLE_COLLATE_FILENAME, group(collation_name | DATABASE_DEFAULT)))
                        +   maybe(assign(FILETABLE_PRIMARY_KEY_CONSTRAINT_NAME, constraint_name))
                        +   maybe(assign(FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME, constraint_name))
                        +   maybe(assign(FILETABLE_FULLPATH_UNIQUE_CONSTRAINT_NAME, constraint_name))
                        +   maybe(assign(SYSTEM_VERSIONING, ON 
                                + maybe(paren(
                                    assign(HISTORY_TABLE, schema_name + ascii.Period + history_table_name),
                                    maybe(assign(DATA_CONSISTENCY_CHECK, group(ON | OFF)))
                                    ))))
                        +   maybe(assign(REMOTE_DATA_ARCHIVE, 
                                group(ON + maybe(paren(+table_stretch_options))  
                                    | OFF + maybe(paren(assign(MIGRATION_STATE, PAUSED))))))                                                       
                            );

                    public static SyntaxRule create_table()
                       => define(
                           table_name + maybe(AS + FILETABLE)

                          + parenG(+(
                              column_definition
                            | computed_column_definition
                            | column_set_definition
                            | maybe(table_constraint)
                            | maybe(table_index)
                                 )

                         + maybe(PERIOD + FOR + SYSTEM + sx.TIME + (system_start_time_column_name, system_start_time_column_name))
                              )

                         + maybe(ON + group(
                               partition_scheme_name + paren(partition_column_name)
                             | filegroup
                             | @default
                            ))

                         + maybe(FILESTREAM_ON
                             + group(
                                 partition_scheme_name
                                 | filegroup
                                 | @default
                                    )
                                )

                         + maybe(WITH + paren(+table_option))

                           );


                }
            }

        }
    }
}

