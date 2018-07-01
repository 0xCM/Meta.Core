//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Specifies common/well-known environment classifications
/// </summary>
public enum RuntimeEnvironmentKind : byte
{
    /// <summary>
    /// Spcifies that no environment classification has been assigned
    /// </summary>
    None = 0,

    /// <summary>
    /// Identifies a local/isolated environment
    /// </summary>
    Local = 1,

    /// <summary>
    /// Identifies a production environment
    /// </summary>
    Prod = 2,

    /// <summary>
    /// Identifies a development environment
    /// </summary>
    Dev = 3,

    /// <summary>
    /// Identifies a devlopment test environment
    /// </summary>
    DevTest = 4,
    
    /// <summary>
    /// Identifies a QA test environment
    /// </summary>
    QaTest = 5,    

    /// <summary>
    /// Identifies a UAT environment
    /// </summary>
    UserTest = 6,

 
}

