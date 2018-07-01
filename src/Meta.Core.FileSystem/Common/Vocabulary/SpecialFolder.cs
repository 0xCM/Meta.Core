//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

using static metacore;

/// <summary>
/// Analagous to the "Special Folder" concept in windows
/// but instantiated for the metadev domain
/// </summary>
public enum SpecialFolder
{
    None = 0,
    /// <summary>
    /// The top-most root directory in the Dev chain, relative to which all
    /// all Dev.* paths can theoretically be calculated
    /// </summary>
    DevRoot,
    
    /// <summary>
    /// The first level of domain-specific develement segmentation/organization
    /// </summary>
    /// <remarks>
    /// The canonical location of the area root is DevAreaRoot := DevRoot + Folder(Areas)
    /// </remarks>
    DevAreaRoot,

    /// <summary>
    /// A segmented location for a specific development effort, product suite, etc.
    /// </summary>
    /// <remarks>
    /// The canonical location of an area is DevArea(AreaName) := DevAreaRoot + Folder(DevAreaName)
    /// </remarks>
    DevArea,
    
    /// <summary>
    /// The development tool root location
    /// </summary>
    /// <remarks>
    /// Canonical value is given by DevTools := DevRoot + Folder(Tools)
    /// </remarks>
    DevTools,

    /// <summary>
    /// The root location for development assets/resources
    /// </summary>
    /// <remarks>
    /// Canonical value is given by DevAssets := DevRoot + Folder(Assets)
    /// </remarks>
    DevAssets,

    /// <summary>
    /// The root location for development-related temporary files
    /// </summary>
    /// <remarks>
    /// Canonical value is given by DevTemp := DevRoot + Folder(.temp)
    /// </remarks>
    DevTemp,

    /// <summary>
    /// The root location for distribution packages
    /// </summary>
    /// <remarks>
    /// Canonical value is given by DistRoot := DevAssets + Folder(dist)
    /// </remarks>
    DistRoot,

    /// <summary>
    /// The root location for open source code that can be freely combined, 
    /// spliced, reformed, etc.
    /// </summary>
    /// <remarks>
    /// Canonical value is given by OssRoot := DevAreaRoot + Folder(OSS)
    /// </remarks>
    OssRoot
}

