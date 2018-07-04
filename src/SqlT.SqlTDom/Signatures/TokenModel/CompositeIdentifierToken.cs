//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    sealed class CompositeIdentifierToken : SignatureToken<CompositeIdentifierToken>
    {
        public CompositeIdentifierToken(IEnumerable<IdentifierToken> Identifiers)
            : base(Identifiers.FirstOrDefault()?.TokenLevel ?? 0)
        {
            this.Identifiers = Identifiers.ToList();
            this.QuoteType = QuoteType;
        }

        public IReadOnlyList<IdentifierToken> Identifiers { get; }

        public TSql.QuoteType QuoteType { get; }


        public override string ToString()
            => this.Format();

    }




}