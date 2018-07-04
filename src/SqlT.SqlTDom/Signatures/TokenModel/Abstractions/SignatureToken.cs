//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{

    using System.Linq;

    public abstract class SignatureToken
    {
        protected SignatureToken(int TokenLevel)
        {
            this.TokenLevel = TokenLevel;

        }
        public int TokenLevel { get; }

    }

    abstract class SignatureToken<T> : SignatureToken
        where T : SignatureToken<T>
    {


        protected SignatureToken(int TokenLevel)
            : base(TokenLevel)
        {
        

        }

    }


}