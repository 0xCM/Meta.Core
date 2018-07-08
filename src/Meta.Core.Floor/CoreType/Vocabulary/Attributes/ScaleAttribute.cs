//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;
using System.Reflection;

public sealed class ScaleAttribute : DataFacetAttribute
{
    public const string FacetName = "Scale";

    public ScaleAttribute(byte Value)
        : base(new FacetInfo(FacetName, Value))
    {

    }
}

