//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public static class ExpressionMessages
{
    public static IAppMessage StringLengthMismatch(string x, int length)
        => AppMessage.Error($"The string '{x}' has length of {x.Length} which unfortunately does not equal the required length {length}");

}