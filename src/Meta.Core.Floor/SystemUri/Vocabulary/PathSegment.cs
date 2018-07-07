//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public sealed class PathSegment : SemanticIdentifier<PathSegment, Uri>, ISystemUriPart
    {

        public static implicit operator string(PathSegment segment)
            => segment?.ToString() ?? string.Empty;

        public static implicit operator PathSegment(string text)
            => new PathSegment(text);

        public static PathSegment operator + (PathSegment p1, PathSegment p2)
            => new PathSegment(p1.Identifier.OriginalString + p2.Identifier.OriginalString);

        const char separator = '/';

        static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return separator.ToString();
            var normalized = text.Replace('\\', '/');

            return  (normalized.StartsWith(separator) ? normalized : $"{separator}{normalized}").TrimEnd(separator);
            
            
        }

        public PathSegment AppendComponents(params string[] components)
        {
            

            if (components.Length == 0)
                return this;
            string part1 = this.IdentifierText;
            string part2 = string.Join(separator.ToString(), components);
            var sep = string.IsNullOrWhiteSpace(part1) ? string.Empty : separator.ToString();
            return new PathSegment($"{part1}{sep}{part2}");
            
        }

        protected override PathSegment New(string IdentifierText)
            => new PathSegment(IdentifierText);

        PathSegment()
            : base(EmptyUri)
        { }

        public PathSegment(string text)
            : base(new Uri(Normalize(text), UriKind.Relative))
        {

        }

        public PathSegment(Uri uri)
            : base(uri)
        { }

        public char Separator
            => '/';

        public string Text
            => ToString();

    }



}

