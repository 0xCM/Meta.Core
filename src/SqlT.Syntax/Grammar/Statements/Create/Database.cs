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

    using static metacore;
    using static grammar;
    using static SqlGrammar.Choices;
    

    partial class SqlGrammar
    {
        partial class Statements
        {
            partial class Create
            {

                public static class Database
                {
                    public static SyntaxRule two_digit_year_cutoff
                        => integerU();

                    public static SyntaxRule lcid
                        => token();

                    public static SyntaxRule language_name
                        => token();

                    public static SyntaxRule language_alias
                        => token();

                    public static SyntaxRule filegroup_name
                        => token();

                    public static SyntaxRule logical_file_name
                        => token();

                    public static SyntaxRule language_specifier
                        => group(lcid | language_name | language_alias);

                    public static SyntaxRule filestream_option
                        => choices(
                            assign(NON_TRANSACTED_ACCESS, non_transacted_access)
                           | assign(DIRECTORY_NAME, directory_name)
                            );

                    public static SyntaxRule os_file_name
                        => stringLiteral();

                    public static SyntaxRule filestream_path
                        => stringLiteral();

                    public static SyntaxRule size
                        => integerU();

                    public static SyntaxRule max_size
                        => integerU();

                    public static SyntaxRule growth_increment
                        => integerU();

                    public static SyntaxRule filespec
                        => define(
                            paren(delimit(
                                    assign(NAME, logical_file_name),
                                    assign(FILENAME, group(os_file_name | filestream_path)),
                                    maybe(assign(SIZE, size + maybe(size_unit))),
                                    maybe(assign(MAXSIZE, group(max_size + (maybe(size_unit) | UNLIMITED)))),
                                    maybe(assign(FILEGROWTH, group(growth_increment + (maybe(size_unit | AsciiSymbol.Percent)))))
                                          )
                                  )
                            );

                    public static SyntaxRule option
                        => define(
                              FILESTREAM + paren(+filestream_option)
                            | assign(DEFAULT_FULLTEXT_LANGUAGE, language_specifier)
                            | assign(DEFAULT_LANGUAGE, language_specifier)
                            | assign(NESTED_TRIGGERS, on_or_off)
                            | assign(TRANSFORM_NOISE_WORDS, on_or_off)
                            | assign(TWO_DIGIT_YEAR_CUTOFF, two_digit_year_cutoff)
                            | db_chaining
                            | trustworthy

                            );

                    public static SyntaxRule filegroup
                        => define(
                            FILEGROUP
                          + filegroup_name
                          + maybe(
                              maybe(CONTAINS + FILESTREAM) + maybe(DEFAULT)
                            | CONTAINS + MEMORY_OPTIMIZED_DATA
                              )
                          + (+filespec)
                            );

                    public static SyntaxRule create_database()
                        => define(
                            CREATE + DATABASE + database_name
                          + maybe(assign(CONTAINMENT, group(NONE | PARTIAL)))
                          + maybe(ON
                                + maybe(PRIMARY) + (+filespec)
                                + maybe(+filegroup)
                                + maybe(LOG + ON + (+filespec))
                              )
                          + maybe(COLLATE + collation_name)
                          + maybe(WITH + (+option))
                            );
                }
            }
        }
    }
}