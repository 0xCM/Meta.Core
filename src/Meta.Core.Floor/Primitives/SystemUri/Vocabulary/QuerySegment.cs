//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public sealed class QuerySegment : SemanticIdentifier<QuerySegment, Uri>, ISystemUriPart 
    {
        public static implicit operator string(QuerySegment segment)
            => segment?.ToString() ?? string.Empty;

        public static QuerySegment FromCriteria(QueryCriteria criteria)
            => new QuerySegment(criteria.ToString());

        public static QuerySegment FromCriteria((string key, string value)[] criteria)
            => FromCriteria(QueryCriteria.Create(criteria));


        public static implicit operator QuerySegment(string text)
            => new QuerySegment(text);



        protected override QuerySegment New(string text)
            => new QuerySegment(text);



        QuerySegment()
            : base(EmptyUri)
        {

        }

        public QuerySegment(string text)
            : base(SytemUriTemplates.StandardUri(query: text))
        {


        }

        public string Text
            => base.Identifier?.Query ?? string.Empty;


        public QueryCriteria Criteria
            => QueryCriteria.Parse(Text);

        public char Separator
            => '?';

        public override string ToString()
            => Text;


    }



}

