//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    public sealed class SqlMessageIdentity : SemanticIdentifier
        <
            SqlMessageIdentity, 
            (SqlMessageNumber MessageNumber, string Language, SqlMessageIdentifier MessageIdentifier)
        >
    {
        public static implicit operator SqlMessageIdentity(SqlMessageNumber MessageNumber)
            => new SqlMessageIdentity(MessageNumber);

        public static implicit operator int(SqlMessageIdentity Identifier)
            => Identifier.MessageId;

        public SqlMessageIdentity(SqlMessageNumber MessageNumber)
            : base((MessageNumber, "us_english", SqlMessageIdentifier.Empty))
        {

        }
        public SqlMessageIdentity((SqlMessageNumber MessageNumber, string LanguageName, SqlMessageIdentifier MessageIdentifier) Value)
            : base(Value)
        {

        }

        public SqlMessageIdentity(SqlMessageNumber MessageNumber, string LanguageName)
            : base((MessageNumber, LanguageName, SqlMessageIdentifier.Empty))
        {

        }

        public SqlMessageIdentity(SqlMessageNumber MessageNumber, string LanguageName, SqlMessageIdentifier MessageIdentifier)
            : base((MessageNumber, LanguageName, MessageIdentifier))
        {

        }

        protected override SqlMessageIdentity New(string IdentityText)
            => new SqlMessageIdentity(
                tuple.parse<int, string, SqlMessageIdentifier>(IdentityText)
                     .ValueOrDefault((0, "us_english", SqlMessageIdentifier.Empty)));

        public bool IsCustomMessage
            => this.Identifier.MessageNumber >= 50001;

        public int MessageId
            => this.Identifier.MessageNumber;

        public string Language
            => this.Identifier.Language;

        public SqlMessageIdentifier MessageIdentifier
            => this.Identifier.MessageIdentifier;

        public override string ToString()
            => MessageId.ToString();
    }
}