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
    /// Specifies an element's summary description
    /// </summary>
    public sealed class ElementDescription : CodeDocumentationSpec
    {
        public static implicit operator ElementDescription(string x)
            => new ElementDescription(x);

        public ElementDescription(string Text)
            : base(Text)
        { }
    }
}
