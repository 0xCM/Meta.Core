//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Defines standard environment variables
/// </summary>
public static class EnvironmentVariables
{
    public static readonly EnvironmentVariable DevTools = new EnvironmentVariable(nameof(DevTools));
    public static readonly EnvironmentVariable DevRoot = new EnvironmentVariable(nameof(DevRoot));
    public static readonly EnvironmentVariable DevAssets = new EnvironmentVariable(nameof(DevAssets));
    public static readonly EnvironmentVariable DistRootDir = new EnvironmentVariable(nameof(DistRootDir));
    public static readonly EnvironmentVariable DevAreaRoot = new EnvironmentVariable(nameof(DevAreaRoot));
    public static readonly EnvironmentVariable DevOps = new EnvironmentVariable(nameof(DevOps));
    public static readonly EnvironmentVariable DevTemp = new EnvironmentVariable(nameof(DevTemp));
    public static readonly EnvironmentVariable SystemNode = new EnvironmentVariable(nameof(SystemNode));
    public static readonly EnvironmentVariable SystemRoot = new EnvironmentVariable(nameof(SystemRoot));
    public static readonly EnvironmentVariable SystemStart = new EnvironmentVariable(nameof(SystemStart));
}
