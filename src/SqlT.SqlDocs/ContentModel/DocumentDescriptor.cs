//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using static metacore;

    public sealed class DocumentDescriptor : SqlDocPartContent<DocumentDescriptor, DocDescriptorPart>
    {

        IDictionary<string,string> _Attributes { get; }
            = new Dictionary<string,string>();
        List<string> _HelpKeywords { get; }
            = new List<string>();

        public DocumentDescriptor()
            : base(string.Empty)
        {
            
        }


        public string Segment { get; set; }

        public string Title { get; set; }


        public Option<Date> ModifiedDate { get; set; }


        public IReadOnlyList<string> HelpKeywords
            => _HelpKeywords;                   

        public IEnumerable<NamedValue> Attributes
            => _Attributes.Select(x => new NamedValue(x.Key,x.Value));

        public void AddHelpKeyword(string keyword)
            => _HelpKeywords.Add(keyword);

        public void AddAttribute(string name, string value)
        {            
            switch (name)
            {               
                case DocDescriptorPart.AttributeNames.date:
                    try_parse<Date>(value).OnSome(date => ModifiedDate = date);
                    break;
                case DocDescriptorPart.AttributeNames.title:
                    Title = value;
                    break;
            }
            _Attributes[name] = value;
        }
    }

}