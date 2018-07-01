//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using static metacore;

/// <summary>
/// Classfies file system changes
/// </summary>
public enum FileChangeKind
{
    None = 0,
    
    /// <summary>
    /// Indicates a file was added
    /// </summary>
    Added = 1,

    /// <summary>
    /// Indicates a file was removed
    /// </summary>
    Removed = 2,

    /// <summary>
    /// Indicates a file was modified
    /// </summary>
    Modifed = 3
}
