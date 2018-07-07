//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public sealed class SqlContentType : SemanticIdentifier<SqlContentType, string>
    {
        public static implicit operator string(SqlContentType x)
            => x.Identifier;

        public SqlContentType(string value)
            : base(value)
        {

        }

        SqlContentType()
           : base(string.Empty)
        {

        }

        protected override SqlContentType New(string IdentifierText)
            => new SqlContentType(IdentifierText);
    }
}