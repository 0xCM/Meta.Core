//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public class QueryCriteria : TypedItemList<QueryCriteria, QueryCriterion>
    {

        public static implicit operator string(QueryCriteria segment)
            => segment?.ToString() ?? string.Empty;

        public static implicit operator QueryCriteria(string text)
            => Parse(text);

        public static QueryCriteria Create(IEnumerable<(string, string)> criteria)
            => Create(from kvp in criteria select new QueryCriterion(kvp.Item1, kvp.Item2));
               

        public static QueryCriteria Parse(string text)
            => Create(ParseCriteria(text));

        static IEnumerable<QueryCriterion> ParseCriteria(string text)
        {
            var uri = SytemUriTemplates.StandardUri(query: text);
            foreach (var kvp in uri.ParseQueryString())
                yield return new QueryCriterion(kvp.Key, kvp.Value);
        }

        public QueryCriteria()
            : base('&')
        {


        }

        public IEnumerable<NamedValue> ToNamedValues()
            => this.Select(x => x.ToNamedValue());


    }



}

