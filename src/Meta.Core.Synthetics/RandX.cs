//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
