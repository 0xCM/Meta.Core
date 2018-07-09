//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// Describes an error encountered when attempting to parse a SQL block
    /// </summary>
    public class SqlParseError
    {
        internal static SqlParseError FromParserResult(string Input, IEnumerable<TSql.ParseError> errors)
            => new SqlParseError(Input,
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
