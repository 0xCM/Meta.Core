//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    using L = Tools;
    using I = Tooldentifier;

    /// <summary>
    /// Identifies an executable 
    /// </summary>
    public class Tooldentifier : SemanticIdentifier<I, string>
    {

        public static FileName operator +(I id, FileExtension ext)
            => FileName.Parse(id) + ext;

        public static implicit operator I(string x)
            => new I(x);

        protected override I New(string text)
            => new I(text ?? string.Empty);


        Tooldentifier()
            : base(string.Empty)
        { }

        public Tooldentifier(string text)
            : base(text)
        {

        }
    }


    public sealed class Tools : ToolIdentifiers<L>
    {
        public Tools()
        {

        }
    }

}