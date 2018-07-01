//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public class DevProjectName : SemanticIdentifier<DevProjectName, string>
    {

        public static implicit operator DevProjectName(string x)
            => new DevProjectName(x);

        protected override DevProjectName New(string IdentifierText)
            => new DevProjectName(IdentifierText ?? string.Empty);


        DevProjectName()
            : base(string.Empty)
        { }

        public DevProjectName(string text)
            : base(text)
        {

        }

        public DevProjectName(char delimiter, params string[] NameComponents)
            : base(string.Join(delimiter.ToString(), NameComponents))
        {

        }

    }


}