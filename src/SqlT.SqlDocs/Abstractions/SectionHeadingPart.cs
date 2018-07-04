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
    using static metacore;

    public abstract class SectionHeadingPart<H> : SqlDocPart<H>
        where H : SectionHeadingPart<H>
    {

        protected SectionHeadingPart(int HeaderLevel, string HeaderText)
        {
            this.HeaderLevel = HeaderLevel;
            this.HeaderText = HeaderText;
        }


        protected SectionHeadingPart()
        {
            this.HeaderLevel = 0;
            this.HeaderText = string.Empty;
        }

        public int HeaderLevel { get; }

        public string HeaderText { get; }


        public override string ToString()
            => concat(new string('#', HeaderLevel), space(), HeaderText);

    }

    public sealed class SectionHeadingPart : SectionHeadingPart<SectionHeadingPart>
    {
        public SectionHeadingPart(int HeaderLevel, string HeaderText)
            : base(HeaderLevel, HeaderText)
        {


        }

        public SectionHeadingPart()
        {


        }

    }


}