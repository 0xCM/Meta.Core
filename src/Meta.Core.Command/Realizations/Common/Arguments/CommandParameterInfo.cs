//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

public class CommandParameterInfo
{
    public CommandParameterInfo(string ParameterName, ValueMember Accessor)
    {
        this.ParameterName = ParameterName;
        this.Accessor = Accessor;
    }
    public string ParameterName { get; }

    public ValueMember Accessor { get; }
}
