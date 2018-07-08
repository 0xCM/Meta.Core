//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public static class RandX
    {
        public static byte NextByte(this Random r, byte min, byte max)
        {
            if (min >= max)
                return 0;

            var buffer = new byte[8];
            var next = (byte?)null;
            while (next == null)
            {
                r.NextBytes(buffer);
                for (var i = 0; i < buffer.Length; i++)
                {
                    var candidate = buffer[i];
                    if (candidate >= min && candidate <= max)
                    {
                        next = candidate;
                        break;
                    }
                }
            }
            return next.Value;
        }

    }
}
