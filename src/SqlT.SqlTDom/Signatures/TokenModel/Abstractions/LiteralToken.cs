//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    sealed class LiteralToken : SignatureToken<LiteralToken>
    {
        public LiteralToken(int TokenLevel, TSql.LiteralType LiteralType, string LiteralValue)
            : base(TokenLevel)
        {
            this.LiteralValue = LiteralValue;
            this.LiteralType = LiteralType;
        }

        public TSql.LiteralType LiteralType { get; }

        public string LiteralValue { get; }

        public override string ToString()
            => this.Format();
    }


}