//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public sealed class SqlMessageIdentifier : SemanticIdentifier<SqlMessageIdentifier, string>
    {
        public static implicit operator SqlMessageIdentifier(string x)
            => new SqlMessageIdentifier(x);

        protected override SqlMessageIdentifier New(string text)
            => new SqlMessageIdentifier(text);

        SqlMessageIdentifier()
            : base(string.Empty) { }

        SqlMessageIdentifier(string text)
            : base(text)
        {

        }
    }
}
