//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    [SqlElementType(SqlElementTypeNames.MessageType)]
    public sealed class SqlMessageType : SqlElement<SqlMessageType, SqlMessageTypeName>
    {


        public SqlMessageType(SqlMessageTypeName Name,
            SqlElementDescription Description = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            bool IsIntrinsic = false
            ) : base(Name, Description, Properties,  IsIntrinsic)
        {

        }
    }

    public sealed class SqlMessageTypes : SyntaxList<SqlMessageTypes, SqlMessageType>
    {
        public static implicit operator SqlMessageTypes(SqlMessageType[] MessageTypes)
            => new SqlMessageTypes(MessageTypes);

        public SqlMessageTypes()
        { }

        public SqlMessageTypes(SqlMessageType[] MessageTypes)
            : base(MessageTypes)
        { }
    }
}
