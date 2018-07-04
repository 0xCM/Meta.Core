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



    public sealed class SectionHeading : SqlDocPartContent<SectionHeading, SectionHeadingPart>
    {
        public SectionHeading()
            : base(string.Empty)
        {


        }

        public SectionHeading(string Text, int LineNumber, int Level)
            : base(Text,LineNumber)
        {
            this.Level = Level;
        }

        public int Level { get; set; }

        
        public override string ToString()
            => concat(new string('#', Level), space(), Text);



    }
}