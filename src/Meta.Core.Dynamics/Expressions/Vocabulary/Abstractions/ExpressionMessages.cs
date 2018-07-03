//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public static class ExpressionMessages
{
    public static IApplicationMessage StringLengthMismatch(string x, int length)
        => ApplicationMessage.Error($"The string '{x}' has length of {x.Length} which unfortunately does not equal the required length {length}");

}