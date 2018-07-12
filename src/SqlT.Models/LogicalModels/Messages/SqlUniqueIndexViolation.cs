//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;

    using static metacore;

    using SqlT.Core;

    public class UniqueIndexViolation : SqlErrorDetail<UniqueIndexViolation>
    {
        public const int ErrorNumber = 2601;
        const string MessageTemplate = "Cannot insert duplicate key row in object '@TableName' with unique index '@IndexName'. The duplicate key value is @DuplicateKeyValue";
        static Regex MessageRegex = regex(CreateRegexPattern(MessageTemplate));

        public static IAppMessage CreateMessage(SqlException e)
            => AppMessage.Error(MessageTemplate, new UniqueIndexViolation(e));

        public UniqueIndexViolation(SqlException e)
            : base(e)
        {

        }

        public SqlObjectName TableName { get; }
        public SqlIndexName IndexName { get; }
        public string DuplicateKeyValue { get; }
    }



}