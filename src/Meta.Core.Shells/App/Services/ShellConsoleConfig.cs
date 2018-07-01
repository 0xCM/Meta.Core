//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics.Tracing;

using static metacore;

public class ShellConsoleConfig
{

    public ShellConsoleConfig()
    {
        Width = 100;
        Height = 50;

    }

    public int? Height { get; set; }
    public int? Width { get; set; }
    public bool? Clear { get; set; }
    public ConsoleColor? ForegroundColor { get; set; }
    public ConsoleColor? BackgroundColor { get; set; }
}
