//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using Meta.Core;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using static metacore;
    
    public static class TSqlParseResult
    {
        /// <summary>
        /// Initializes a result with parsed content upon success
        /// </summary>
        /// <typeparam name="T">The parsed content type</typeparam>
        /// <param name="Content">The parsed content</param>
        /// <returns></returns>
        public static TSqlParseResult<T> Success<T>(T Content)
            where T : TSql.TSqlFragment
            => new TSqlParseResult<T>(Content);

        /// <summary>
        /// Initializes a result with error information upon failure
        /// </summary>
        /// <typeparam name="T">The (un)parsed content type</typeparam>
        /// <param name="Error">Erorr information that details the reason for failure</param>
        /// <returns></returns>
        public static TSqlParseResult<T> Failure<T>(SqlParseError Error)
            where T : TSql.TSqlFragment
            => new TSqlParseResult<T>(Error);

        /// <summary>
        /// Creates a successful parse result if no error information is specified;
        /// otherwise, creates a failed parse result
        /// </summary>
        /// <typeparam name="T">The parsed content type</typeparam>
        /// <param name="Content">Parsed content, if successful</param>
        /// <param name="Error">The parse error, if failed</param>
        /// <returns></returns>
        public static TSqlParseResult<T> Create<T>(T Content, Option<SqlParseError> Error)
            where T : TSql.TSqlFragment
            => Error.Map(e => Failure<T>(e), () => Success(Content));            
    }

}
