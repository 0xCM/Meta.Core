//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;



public class DateTimeFacetAttribute : FacetAttribute
{
    public DateTimeFacetAttribute(int index)
        : base(index)
    {

    }

    public int Scale { get; set; }
}

