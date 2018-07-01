//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Specifies a file's footer comments
    /// </summary>
    public sealed class CodeFilePostamble : CodeDocumentationSpec
    {
        public static CodeFilePostamble Default()
            => new CodeFilePostamble($"Generation of this file concluded at {DateTime.Now}");

        public CodeFilePostamble(params string[] lines)
            : base(String.Join("\r\n", lines))
        {
            this.Lines = array(lines);
        }

        public CodeFilePostamble(string text)
            : base(text)
        {
            Lines = array(text);
        }

        /// <summary>
        /// The lines of text to be rendered as the footer
        /// </summary>
        public IReadOnlyList<string> Lines { get; }
    }

}