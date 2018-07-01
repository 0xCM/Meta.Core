//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Text.RegularExpressions;
using System.Linq;

using static metacore;

public static class ScriptParameterExpressions
{
    /// <summary>
    /// Identifies script parameters of the form $(Parameter)
    /// </summary>
    public static readonly Regex ParamType1 = regex(@"\$\((?<Name>(\w)*)\)");

    /// <summary>
    /// Identifies script parameters of the form @Parameter
    /// </summary>
    public static readonly Regex ParamType2 = regex(@"@(?<Name>[a-zA-Z]*)");

    /// <summary>
    /// Identifies script parameters of the form %Parameter%
    /// </summary>
    public static readonly Regex ParamType3 = regex(@"\%(?<Name>[a-zA-Z]*)\%");

}
