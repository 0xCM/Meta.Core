//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
