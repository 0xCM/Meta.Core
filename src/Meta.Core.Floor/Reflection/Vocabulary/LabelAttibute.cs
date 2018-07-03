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
/// Attaches one or more lables to a code element (duh?)
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LabelAttribute : Attribute
{
    public LabelAttribute(string LabelText)
    {
        this.LabelText = LabelText;
    }

    public string LabelText { get; }

    public override string ToString()
       => LabelText;
}

