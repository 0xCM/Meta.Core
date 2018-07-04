//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{

    using System.Linq;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    sealed class FragmentToken : SignatureToken<FragmentToken>
    {

        public static implicit operator string(FragmentToken token)
            => token.Format();

        public FragmentToken(TSql.TSqlFragment Fragment, object TokenizedValue, int Level)
            : base(Level)
        {
            this.Fragment = Fragment;
            this.TokenizedValue = TokenizedValue;
        }

        public TSql.TSqlFragment Fragment { get; }

        public object TokenizedValue { get; }

        public override string ToString()
            => this.Format();
    }

}
