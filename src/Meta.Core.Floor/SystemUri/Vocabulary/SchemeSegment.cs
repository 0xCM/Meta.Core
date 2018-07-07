//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public sealed class SchemeSegment : SemanticIdentifier<SchemeSegment, string>, ISystemUriPart
    {

        public static implicit operator string(SchemeSegment segment)
            => segment?.ToString() ?? string.Empty;

        public static implicit operator SchemeSegment(string text)
                => new SchemeSegment(text);

        public static SchemeSegment Default = new SchemeSegment();

        protected override SchemeSegment New(string text)
            => new SchemeSegment(text);

        SchemeSegment()
            : base(string.Empty)
        { }

        public SchemeSegment(string Identifier)
            : base(Identifier)
        { }


        public string[] Components
            => IdentifierText.Split(Separator);

        public char Separator
            => '.';

        

        public string Text
            => ToString();

        public SchemeSegment ReplaceComponent(int idx, string name)
        {
            var components = Components;
            if (idx < components.Length - 1)
                return this;        
            components[idx] = name;

            return Parse(string.Join(Separator.ToString(), components));

        }
    }



}
