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

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    [SqlElementType(SqlElementTypeNames.User)]
    public sealed class SqlUser : SqlElement<SqlUser>
    {

        public SqlUser
            (
                SqlUserName Name,
                string Password = null, 
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null
            ) : base(Name, Documentation, Properties)
        {
            this.Password = Password ?? String.Empty;
        }


        public string Password { get; }

        public override string ToString() 
            => isBlank(Password) ? ElementName.ToString() : $"{ElementName}/{Password}";
    }
}
