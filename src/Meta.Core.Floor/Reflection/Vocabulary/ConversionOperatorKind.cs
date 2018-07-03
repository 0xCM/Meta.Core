//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

/// <summary>
/// Classifies a conversion operator
/// </summary>
public enum ConversionOperatorKind
{

    /// <summary>
    /// Indicates that the conversion type is unspecified
    /// </summary>
    [Description("Indicates that the conversion type is unspecified")]
    None,
    
    /// <summary>
    /// Specifies that a conversion operator is implicit
    /// </summary>
    [Description("Specifies that a conversion operator is implicit")]
    Implicit,
    
    /// <summary>
    /// Specifies that a conversion operator is explicit
    /// </summary>
    [Description("Specifies that a conversion operator is explicit")]
    Explicit
}


