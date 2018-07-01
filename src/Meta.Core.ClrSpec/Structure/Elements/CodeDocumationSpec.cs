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
    /// Base type for code element documentation specifications
    /// </summary>
    public abstract class CodeDocumentationSpec : ValueObject<CodeDocumentationSpec>
    {

        public CodeDocumentationSpec(string Text)
        {
            this.Text = Text;
        }

        /// <summary>
        /// Specifies the documentation content
        /// </summary>
        public string Text { get; }

        public override string ToString() 
            => Text;
    }
}
