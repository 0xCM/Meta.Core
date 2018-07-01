//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using static metacore;

/// <summary>
/// Indicates that the literal values of the target can by used to partition a set into equivalence classes
/// </summary>
[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public class PartitionAttribute : Attribute
{
    public PartitionAttribute()
    {
    }


}
