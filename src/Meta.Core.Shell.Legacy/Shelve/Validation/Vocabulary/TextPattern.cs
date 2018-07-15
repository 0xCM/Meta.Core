//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Encapsulates a regular expression
    /// </summary>
    public class TextPattern 
    {
        public static implicit operator string(TextPattern x) 
            => x.Text;

        public static implicit operator TextPattern(string x) 
            => new TextPattern(x);


        public TextPattern(string Text)
        {
            this.Text = Text;
        }

        public string Text { get; }

        public override string ToString() 
            => Text;
        
    }
}
