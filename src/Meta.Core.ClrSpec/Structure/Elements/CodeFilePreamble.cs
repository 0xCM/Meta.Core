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
    /// Specifies a file's header comments
    /// </summary>
    public sealed class CodeFilePreamble : CodeDocumentationSpec
    {

        public static CodeFilePreamble operator +(CodeFilePreamble x, CodeFilePreamble y)
            => new CodeFilePreamble(Enumerable.Concat(x.Lines, y.Lines).ToArray());

        public static CodeFilePreamble Default()
            => new CodeFilePreamble($"Generation of this file began at {DateTime.Now}");

        public CodeFilePreamble(params string[] lines)
            : base(String.Join("\r\n", lines))
        {
            this.Lines = array(lines);
        }

        public CodeFilePreamble(string text)
            : base(text)
        {
            Lines = array(text);
        }

        public IReadOnlyList<string> Lines { get; }
    }
}