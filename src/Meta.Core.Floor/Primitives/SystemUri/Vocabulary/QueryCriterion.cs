//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public struct QueryCriterion : ISystemUriPart
    {
        public static implicit operator string(QueryCriterion segment)
            => segment.ToString();

        public static implicit operator NamedValue(QueryCriterion segment)
            => segment.ToNamedValue();

        public static QueryCriterion Parse(string criterion)
        {
            var uri = new Uri($"scheme://host/path?{criterion}");
            var index = uri.ParseQueryString();
            if (index.Count >= 1)
                return new QueryCriterion(index.First().Key, index.First().Value);
            else
                return new QueryCriterion(string.Empty, criterion);
            
        }


        public QueryCriterion(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public string Key { get; }

        public string Value { get; }

        public char Separator
            => '=';

        public override string ToString()
            => $"{Key}{Separator}{Value}";

        public override int GetHashCode()
            => ToString().ToLowerInvariant().GetHashCode();

        public override bool Equals(object obj)
            => ToString().Equals((obj?.ToString() ?? string.Empty), StringComparison.InvariantCultureIgnoreCase);

        public string Text
            => ToString();

        public NamedValue ToNamedValue()
            => new NamedValue(Key, Value);

    }



}

