//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Services;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// Describes an error encountered when attempting to parse a SQL block
    /// </summary>
    public class SqlParseError
    {
        internal static SqlParseError FromParserResult(string Input, IEnumerable<TSql.ParseError> errors)
            =>
            new SqlParseError(Input,
                map(errors, error
                    => new SqlParseErrorMessage(
                            error.Number,
                            error.Offset,
                            error.Line,
                            error.Column,
                            error.Message
                        )
                ));

        public SqlParseError(string Input, IEnumerable<SqlParseErrorMessage> Messages)
        {
            this.Input = Input;
            this.Messages = Messages.ToList();
        }

        /// <summary>
        /// The objectionable SQL
        /// </summary>
        public string Input { get; }

        public IReadOnlyList<SqlParseErrorMessage> Messages { get; }

        public string Description
            => join(";", Messages.ToArray());

        public override string ToString()
            => Description;
            
    }


}
