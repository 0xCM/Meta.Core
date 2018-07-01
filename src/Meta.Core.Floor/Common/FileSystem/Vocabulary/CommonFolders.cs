//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;
using static metacore;

public class CommonFolders : TypedItemList<CommonFolders, FolderPath>
{
    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevTools"/> variable
    /// </summary>
    public static readonly FolderPath DevTools = FolderPath.Parse(EnvironmentVariables.DevTools);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevRoot"/> variable
    /// </summary>
    public static readonly FolderPath DevRoot = FolderPath.Parse(EnvironmentVariables.DevRoot);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevAssets"/> variable
    /// </summary>
    public static readonly FolderPath DevAssets = FolderPath.Parse(EnvironmentVariables.DevAssets);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DistRootDir"/> variable
    /// </summary>
    public static readonly FolderPath DistRootDir = FolderPath.Parse(EnvironmentVariables.DistRootDir);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevAreaRoot"/> variable
    /// </summary>
    public static readonly FolderPath DevAreaRoot = FolderPath.Parse(EnvironmentVariables.DevAreaRoot);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevOps"/> variable
    /// </summary>
    public static readonly FolderPath DevOps = FolderPath.Parse(EnvironmentVariables.DevOps);

    /// <summary>
    /// Specifies the folder defined by <see cref="EnvironmentVariables.DevTemp"/> variable
    /// </summary>
    public static readonly FolderPath DevTemp = FolderPath.Parse(EnvironmentVariables.DevTemp);

    /// <summary>
    /// Specifies the conventional location of the root open source folder
    /// </summary>
    public static readonly FolderPath OssRoot = DevAreaRoot + FolderName.Parse("OSS");
    /// <summary>
    /// Computes the area folder based on the <see cref="EnvironmentVariables.DevTools"/> variable
    /// </summary>
    public static FolderPath DevArea(FolderName Area)
        => DevAreaRoot + Area;
}