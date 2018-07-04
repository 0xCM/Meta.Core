//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    sealed class FragmentTokens : TypedItemList<FragmentTokens, FragmentToken>
    {
        public static FragmentTokens One(FragmentToken token)
            => Create(new FragmentToken[] { token });

        public static implicit operator FragmentTokens(FragmentToken[] tokens)
            => Create(tokens);

        public FragmentTokens()
            : base('*')
        { }

    }

}
