//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class TextFacetAttribute : FacetAttribute
{
    public TextFacetAttribute(int index)
        : base(index)
    {
        Length = -1;
    }

    public int Length { get; set; }
}


