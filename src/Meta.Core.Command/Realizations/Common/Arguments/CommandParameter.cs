//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class CommandParameterAttribute : Attribute
{

    public CommandParameterAttribute()
    {

    }

    public CommandParameterAttribute(string ParameterDescription)
    {
        this.ParameterDescription = ParameterDescription;
    }


    public string ParameterName { get; set; }

    public string ParameterDescription { get; set; }

}

